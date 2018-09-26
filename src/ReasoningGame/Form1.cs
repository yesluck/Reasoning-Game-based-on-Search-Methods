using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReasoningGame
{
    public partial class Form1 : Form
    {
        /******************************以下为变量类型声明段******************************/

        Random randomizer = new Random();   //随机数种子
        int timeLeft = 0;
        bool CheckTheAnswer = false;

        //游戏属性
        class Property
        {
            public int mode;                //模式：计算机解题=1，人工解题=2
            public int type;                //问题类型：牧师/骗子/赌棍=1，正确/错误/部分=2
            public int set;                 //出题方式：默认题目=1，随机出题=2
            public int style;               //题目形式，适合类型1问题：无否定句=1，有否定句=2
            public int background;          //问题背景，适合类型2问题：矿石选择=1，挂科惨案=2，咖啡猜测=3，考试成绩易=4，考试成绩难=5

            //属性构造函数，属性由传入的参数决定
            public Property(int mode0, int type0, int set0, int style0, int background0)
            {
                mode = mode0;
                type = type0;
                set = set0;
                style = style0;
                background = background0;
            }
        }
        Property gameProperty = new Property(1, 1, 1, 1, 1);    //构造游戏属性对象
        
        //人物
        class Character
        {
            public int identity;            //身份，适合类型1问题：牧师=1，骗子=2，赌棍=3，骗子赌棍存疑=4
            public bool am;                 //适合类型1问题：是=true，不是=false
            public int statement;           //人物声明，适合类型1问题：我是牧师=1，我是骗子=2，我是赌棍=3

            public int accuracy;            //正确性，适合类型2问题，正确的话语个数

            /// <summary>
            /// 个人判断，适合类型2问题
            /// 一维：个人判断，[0]第一句，[1]第二句，[2]第三句
            /// 二维[0]：“而是”=1、“不是”=2；二维[1]:属性（1锡2铁3铜）（。。。）
            /// Judgement[0,0]第一句“而是”/“不是”性质        [0,1]第一句属性（1锡2铁3铜）（。。。）
            /// Judgement[1,0]第二句“而是”/“不是”性质        [1,1]第一句属性（1锡2铁3铜）（。。。）
            /// Judgement[2,0]第三句“而是”/“不是”性质        [2,1]第一句属性（1锡2铁3铜）（。。。）
            /// </summary>
            public int[,] Judgement = new int[3, 2];    //一维：个人判断，[0]第一句，[1]第二句，[2]第三句
                                                        //二维[0]：“而是”=1、“不是”=2；二维[1]:属性（1锡2铁3铜）（。。。）

            //人物构造函数（默认状态下为0）
            public Character()
            {
                identity = 0;
                statement = 0;
                accuracy = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Judgement[i, j] = 0;
                    }
                }
            }
        }
        Character[] character = new Character[]     //构造游戏的4个人物对象
        {
            new Character(),new Character(),new Character(),new Character()
        };

        //用自然语言表示的段落结构
        class Paragraph
        {
            public string firstSentence;    //段落的第一句话
            public string[] name = new string[4];   //每个人的名字：[0]第一个人，[1]第二个人，[2]第三个人，[3]第四个人
            public string lastSentence;     //段落的最后一句话
            public string note;             //备注

            //适合类型1
            public string leftState = "说：“";
            public string[] Iam = new string[3];
            public string rightState = "”。";
            public string[] statement = new string[3];

            //适合类型2
            public string leftGuess = "判断：“";
            public string rightGuess = "。”";

            //适合类型2答案显示
            public string itIs;
            public string answer;

            /// <summary>
            /// 每个人的“而是”/“不是”语句
            /// 一维：人物，[0]甲，[1]乙，[2]丙，[3]丁
            /// 二维：语句，[0]第一句，[1]第二句，[2]第三句
            /// IsOrNot[0,0]甲的第1个“而是”/“不是”语句    IsOrNot[0,1]甲的第2个“而是”/“不是”语句    IsOrNot[0,2]甲的第3个“而是”/“不是”语句
            /// IsOrNot[1,0]乙的第1个“而是”/“不是”语句    IsOrNot[1,1]乙的第2个“而是”/“不是”语句    IsOrNot[1,2]乙的第3个“而是”/“不是”语句
            /// IsOrNot[2,0]丙的第1个“而是”/“不是”语句    IsOrNot[2,1]丙的第2个“而是”/“不是”语句    IsOrNot[2,2]丙的第3个“而是”/“不是”语句
            /// IsOrNot[3,0]丁的第1个“而是”/“不是”语句    IsOrNot[3,1]丁的第2个“而是”/“不是”语句    IsOrNot[3,2]丁的第3个“而是”/“不是”语句
            /// </summary>
            public string[,] IsOrNot = new string[4, 3];

            /// <summary>
            /// 每个人的属性判断语句
            /// 一维：人物，[0]甲，[1]乙，[2]丙，[3]丁
            /// 二维：语句，[0]第一句，[1]第二句，[2]第三句
            /// Guess[0,0]甲的第1个属性判断语句    Guess[0,1]甲的第2个属性判断语句    Guess[0,2]甲的第3个属性判断语句
            /// Guess[1,0]乙的第1个属性判断语句    Guess[1,1]乙的第2个属性判断语句    Guess[1,2]乙的第3个属性判断语句
            /// Guess[2,0]丙的第1个属性判断语句    Guess[2,1]丙的第2个属性判断语句    Guess[2,2]丙的第3个属性判断语句
            /// Guess[3,0]丁的第1个属性判断语句    Guess[3,1]丁的第2个属性判断语句    Guess[3,2]丁的第3个属性判断语句
            /// </summary>
            public string[,] Guess = new string[4, 3];
        }
        Paragraph para = new Paragraph();

        string question;                    //显示在问题框中的问题语句
        string[] Quote = new string[4];     //人物对话框，[0]甲，[1]乙，[2]丙，[3]丁

        class typeAProperty
        {
            public int lierStatement;                       //若有人声明自己是骗子，标记他的编号，无人为-1
            public int[] gamblerStatement = new int[2];     //若有人声明自己是赌棍，标记他的编号，无人为-1
            public int[] pastorStatement = new int[2];      //若有人声明自己是牧师，标记他的编号，无人为-1

            public int[] personIdentity = new int[4];       //枚举每个身份所对应的人 [1]牧师，[2]骗子，[3]赌棍

            public int score;                               //积分。每有一个合理的话语积一分。

            public bool questioning;                        //是否正在出题状态
            public int solveSum;                            //出题状态时使用：可能的解数
        }
        typeAProperty typeAproperty = new typeAProperty();

        class typeBProperty
        {
            public int thing;                               //实际物品

            public int totalThings;                         //物品总数
            public int totalGuessperPerson;                 //每人的猜测数

            public int[] accuracy=new int [4];              //每个人说话的正确性。[0]第一个人，[1]第二个人，[2]第三个人，[3]第四个人
            public int[] accuNum = new int[4];              //accuNum[i]：对i句话的人的编号

            public int score;                               //积分。每个人说对的第一句话积5分，说对的第二句话积3分，（说对的第三句话积2分，）说错的话积1分。

            public bool questioning;                        //是否正在出题状态
            public int solveSum;                            //出题状态时使用：可能的解数
            public int difficulty;                          //难度（适合于背景4、5）
        }
        typeBProperty typeBproperty = new typeBProperty();
        typeBProperty typeBRandomProperty = new typeBProperty();

        /******************************以上为变量类型声明段******************************/
        /********************************以下为游戏函数段********************************/

        /// <summary>
        /// 匹配UI细节
        /// </summary>
        public void UIMatch()
        {
            this.dialogBox4.Location = new Point(555, 220);
            this.dialogLabelD.Location = new Point(593, 238);
            this.dialogLabelA.Size = new Size(113, 40);
            this.dialogLabelB.Size = new Size(113, 40);
            this.dialogLabelC.Size = new Size(113, 40);
            identityBoxD.Enabled = false;
            if(gameProperty.type == 1)
            {
                pictureBox1.Image = Resource1.type1;
            }
            else if(gameProperty.type == 2)
            {
                if(gameProperty.background == 1)
                {
                    pictureBox1.Image = Resource1.BG1;
                }
                else if(gameProperty.background == 2)
                {
                    pictureBox1.Image = Resource1.WechatIMG10;
                    this.dialogLabelA.Size = new Size(130, 40);
                    this.dialogLabelB.Size = new Size(130, 40);
                    this.dialogLabelC.Size = new Size(130, 40);
                }
                else if(gameProperty.background == 3)
                {
                    pictureBox1.Image = Resource1.BG3;
                }
                else if(gameProperty.background == 4 || gameProperty.background == 5)
                {
                    pictureBox1.Image = Resource1.BG45;
                    this.dialogBox4.Location = new Point(370, 220);
                    this.dialogLabelD.Location = new Point(407, 238);
                    if (gameProperty.mode == 2) identityBoxD.Enabled = true;
                }
            }
        }

        /// <summary>
        /// 类型1问题，匹配人物及其声明
        /// </summary>
        public void StatementMatch()
        {
            for (int i = 0; i < 3; i++)
            {
                if (character[i].am == true) para.Iam[i] = "我是";
                else if (character[i].am == false) para.Iam[i] = "我不是";
                if (character[i].statement == 1) para.statement[i] = "牧师";
                else if (character[i].statement == 2) para.statement[i] = "骗子";
                else if (character[i].statement == 3) para.statement[i] = "赌棍";
            }
        }

        /// <summary>
        /// 类型2问题，匹配人物及其声明
        /// </summary>
        public void GuessMatch()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (character[i].Judgement[j, 0] == 1) para.IsOrNot[i, j] = "而是";
                    else if (character[i].Judgement[j, 0] == 2) para.IsOrNot[i, j] = "不是";
                }
            }

            if (gameProperty.background == 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (character[i].Judgement[j, 1] == 1) para.Guess[i, j] = "锡";
                        else if (character[i].Judgement[j, 1] == 2) para.Guess[i, j] = "铁";
                        else if (character[i].Judgement[j, 1] == 3) para.Guess[i, j] = "铜";
                    }
                }
            }

            if (gameProperty.background == 2)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (character[i].Judgement[j, 1] == 1) para.Guess[i, j] = "应用随机过程";
                        else if (character[i].Judgement[j, 1] == 2) para.Guess[i, j] = "人工智能导论";
                        else if (character[i].Judgement[j, 1] == 3) para.Guess[i, j] = "计算机网络";
                    }
                }
            }

            if (gameProperty.background == 3)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (character[i].Judgement[j, 1] == 1) para.Guess[i, j] = "卡布奇诺";
                        else if (character[i].Judgement[j, 1] == 2) para.Guess[i, j] = "拿铁咖啡";
                        else if (character[i].Judgement[j, 1] == 3) para.Guess[i, j] = "蓝山咖啡";
                    }
                }
            }

            if (gameProperty.background == 4 || gameProperty.background == 5)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (character[i].Judgement[j, 1] == 1) para.Guess[i, j] = "第一";
                        else if (character[i].Judgement[j, 1] == 2) para.Guess[i, j] = "第二";
                        else if (character[i].Judgement[j, 1] == 3) para.Guess[i, j] = "第三";
                        else if (character[i].Judgement[j, 1] == 4) para.Guess[i, j] = "第四";
                    }
                }
            }
        }

        /// <summary>
        /// 根据几个数组的代码，将问题和每个人的对话框语句转化为自然语言
        /// </summary>
        public void ParagraphTrans()
        {
            //如果是“牧师/骗子/赌棍”问题
            if (gameProperty.type == 1)
            {
                para.firstSentence = "甲乙丙三人中有一人是牧师，有一人是骗子，还有一人是赌棍。牧师从不说谎，骗子总说谎，赌棍有时说真话有时说谎话。";
                para.name[0] = "甲";
                para.name[1] = "乙";
                para.name[2] = "丙";
                para.lastSentence = "请问：甲乙丙三人中谁是牧师？谁是骗子？谁是赌棍？";
                para.note = "（备注：如果有两人说了相同的话，那么先说的人可信度较高。）";
                question = para.firstSentence;
                for (int i = 0; i < 3; i++)
                {
                    question += para.name[i];
                    question += para.leftState;
                    question += para.Iam[i];
                    question += para.statement[i];
                    question += para.rightState;
                }
                question += para.lastSentence;
                if (gameProperty.set == 2 && gameProperty.style == 1)
                {
                    question += "\n";
                    question += para.note;
                }

                for (int i = 0; i < 3; i++)
                {
                    Quote[i] = "";
                }
                for (int i = 0; i < 3; i++)
                {
                    Quote[i] = para.Iam[i] + para.statement[i] + "。";
                }
            }

            //如果是“正确/错误/部分”问题
            else if(gameProperty.type == 2)
            {
                if (gameProperty.background == 1)
                {
                    para.firstSentence = "某地质学院的三名学生对一种矿石进行分析。";
                    para.name[0] = "甲";
                    para.name[1] = "乙";
                    para.name[2] = "丙";
                    para.lastSentence = "经化验证明，有一个人判断完全正确，一个人只说对了一半，一个人则完全说错。那么谁说对了一半？";
                }
                else if(gameProperty.background == 2)
                {
                    para.firstSentence = "某学渣本学期挂了自动化系专业限选课A组的其中一门。他的三位舍友以深切同情的态度对他挂的科目进行了猜测。";
                    para.name[0] = "一号床";
                    para.name[1] = "二号床";
                    para.name[2] = "三号床";
                    para.lastSentence = "经过令人发指的详细追问后发现，有一个人判断完全正确，一个人只说对了一半，一个人则完全说错。那么谁说对了一半？";
                }
                else if (gameProperty.background == 3)
                {
                    para.firstSentence = "在 Rabbit House 咖啡厅内，三名可爱的初中生对保登心爱酱准备端上来的咖啡种类进行了猜测。";
                    para.name[0] = "惠酱";
                    para.name[1] = "智乃酱";
                    para.name[2] = "麻耶酱";
                    para.lastSentence = "咖啡端上来后，大家发现，有一个人判断完全正确，一个人只说对了一半，一个人则完全说错。请分析三人猜测的正确性。";
                }
                else if (gameProperty.background == 4 || gameProperty.background == 5)
                {
                    para.firstSentence = "大学神林若谷本学期考进了自动化系的年级前四。他的四位高中同学在他于“王品台塑牛排”举办的庆祝宴席上对他的年级排名进行了猜测。";
                    para.name[0] = "林同学";
                    para.name[1] = "黄同学";
                    para.name[2] = "蔡同学";
                    para.name[3] = "刘同学";
                    para.lastSentence = "酒足饭饱之后，林若谷豪迈地传授了自己的感情经验，并公布了他的年级排名。大家发现，有一个人判断完全正确，两个人只说对了一半，一个人则完全说错。请分析四人猜测的正确性。";
                }
                question = para.firstSentence;
                if (gameProperty.background < 4 && gameProperty.background > 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        question += para.name[i];
                        question += para.leftGuess;
                        for (int j = 0; j < 2; j++)
                        {
                            question += para.IsOrNot[i, j];
                            question += para.Guess[i, j];
                            if (j == 0) question += "，";
                        }
                        question += para.rightGuess;
                    }
                }
                else if (gameProperty.background == 4 || gameProperty.background == 5)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        question += para.name[i];
                        question += para.leftGuess;
                        for (int j = 0; j < 2; j++)
                        {
                            question += para.IsOrNot[i, j];
                            question += para.Guess[i, j];
                            if (j == 0) question += "，";
                        }
                        question += para.rightGuess;
                    }
                }
                question += para.lastSentence;

                for (int i = 0; i < 4; i++)
                {
                    Quote[i] = "";
                }
                if (gameProperty.background < 4 && gameProperty.background > 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            Quote[i] += para.IsOrNot[i, j];
                            Quote[i] += para.Guess[i, j];
                            if (j < 1) Quote[i] += "，";
                            else if (j == 1) Quote[i] += "。";
                        }
                    }
                }
                else if (gameProperty.background == 4 || gameProperty.background == 5)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            Quote[i] += para.IsOrNot[i, j];
                            Quote[i] += para.Guess[i, j];
                            if (j < 1) Quote[i] += "，";
                            else if (j == 1) Quote[i] += "。";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 改变身份下拉选择栏和身份答案栏的内容和格式
        /// </summary>
        public void IdentityBoxLabelChange()
        {
            if (gameProperty.type == 1)
            {
                identityBoxA.Text = "请选择他的身份";
                identityBoxB.Text = "请选择他的身份";
                identityBoxC.Text = "请选择他的身份";
                identityLabelA.Text = "真实身份";
                identityLabelB.Text = "真实身份";
                identityLabelC.Text = "真实身份";
                identityBoxA.Items.Clear();
                identityBoxB.Items.Clear();
                identityBoxC.Items.Clear();
                identityBoxA.Items.Add("牧师");
                identityBoxA.Items.Add("赌棍");
                identityBoxA.Items.Add("骗子");
                identityBoxB.Items.Add("牧师");
                identityBoxB.Items.Add("赌棍");
                identityBoxB.Items.Add("骗子");
                identityBoxC.Items.Add("牧师");
                identityBoxC.Items.Add("赌棍");
                identityBoxC.Items.Add("骗子");
            }
            else if (gameProperty.type == 2)
            {
                identityBoxA.Text = "请分析这句话的正确性";
                identityBoxB.Text = "请分析这句话的正确性";
                identityBoxC.Text = "请分析这句话的正确性";
                identityBoxD.Text = "请分析这句话的正确性";
                identityLabelA.Text = "答案";
                identityLabelB.Text = "答案";
                identityLabelC.Text = "答案";
                identityLabelD.Text = "答案";
                identityBoxA.Items.Clear();
                identityBoxB.Items.Clear();
                identityBoxC.Items.Clear();
                identityBoxD.Items.Clear();
                identityBoxA.Items.Add("完全正确");
                identityBoxA.Items.Add("只说对了一半");
                identityBoxA.Items.Add("完全说错");
                identityBoxB.Items.Add("完全正确");
                identityBoxB.Items.Add("只说对了一半");
                identityBoxB.Items.Add("完全说错");
                identityBoxC.Items.Add("完全正确");
                identityBoxC.Items.Add("只说对了一半");
                identityBoxC.Items.Add("完全说错");
                if (gameProperty.background == 4 || gameProperty.background == 5)
                {
                    identityBoxD.Items.Add("完全正确");
                    identityBoxD.Items.Add("只说对了一半");
                    identityBoxD.Items.Add("完全说错");
                }
            }
        }

        /// <summary>
        /// 在问题背景切换时，重新命名答案显示的关键词
        /// </summary>
        public void paraAnswerRename()
        {
            if(gameProperty.background == 1)
            {
                para.itIs = "这个矿石是";
                if (typeBproperty.thing == 1) para.answer = "锡";
                else if (typeBproperty.thing == 2) para.answer = "铁";
                else if (typeBproperty.thing == 3) para.answer = "铜";
            }
            else if(gameProperty.background == 2)
            {
                para.itIs = "这名学渣挂科的课程是";
                if (typeBproperty.thing == 1) para.answer = "应用随机过程";
                else if (typeBproperty.thing == 2) para.answer = "人工智能导论";
                else if (typeBproperty.thing == 3) para.answer = "计算机网络";
            }
            else if(gameProperty.background == 3)
            {
                para.itIs = "保登心爱酱端上来的咖啡是";
                if (typeBproperty.thing == 1) para.answer = "卡布奇诺";
                else if (typeBproperty.thing == 2) para.answer = "拿铁咖啡";
                else if (typeBproperty.thing == 3) para.answer = "蓝山咖啡";
            }
            else if (gameProperty.background == 4 || gameProperty.background == 5)
            {
                para.itIs = "大学神林若谷的排名是";
                if (typeBproperty.thing == 1) para.answer = "年级第一";
                else if (typeBproperty.thing == 2) para.answer = "年级第二";
                else if (typeBproperty.thing == 3) para.answer = "年级第三";
                else if (typeBproperty.thing == 4) para.answer = "年级第四";
            }
        }

        /// <summary>
        /// 为“正确/错误/部分”类问题的判断和参数进行初始化
        /// </summary>
        public void TypeBRandomInitialize()
        {
            //初始化总人数、物品数、个人猜想数相关信息
            if (gameProperty.background < 4 && gameProperty.background > 0)
            {
                typeBRandomProperty.totalThings = 3;
                typeBRandomProperty.totalGuessperPerson = 2;
            }
            else if (gameProperty.background == 4 || gameProperty.background == 5)
            {
                typeBRandomProperty.totalThings = 4;
                typeBRandomProperty.totalGuessperPerson = 2;
            }
            //初始化每个人猜想正确数（初始为-1）、初始化每个正确性对应的人（初始为-1）
            for (int k = 0; k < 4; k++)
            {
                typeBRandomProperty.accuracy[k] = -1;
                typeBRandomProperty.accuNum[k] = -1;
            }
            //初始化每个角色的猜想=0。
            for (int m = 0; m < 4; m++)
            {
                for (int n = 0; n < 3; n++)
                {
                    for (int p = 0; p < 2; p++)
                    {
                        character[m].Judgement[n, p] = 0;
                    }
                }
            }
        }

        /// <summary>
        /// 对默认问题的参数和文字进行设置
        /// </summary>
        public void DefaultSetting()
        {
            if (gameProperty.type == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    character[i].am = true;
                }
                character[0].statement = 1;
                character[1].statement = 2;
                character[2].statement = 3;
            }
            else if(gameProperty.type == 2)
            {
                character[0].Judgement[0, 0] = 2;   //不是
                character[0].Judgement[0, 1] = 2;   //铁
                character[0].Judgement[1, 0] = 2;   //不是
                character[0].Judgement[1, 1] = 3;   //铜
                character[1].Judgement[0, 0] = 2;   //不是
                character[1].Judgement[0, 1] = 2;   //铁
                character[1].Judgement[1, 0] = 1;   //而是
                character[1].Judgement[1, 1] = 1;   //锡
                character[2].Judgement[0, 0] = 2;   //不是
                character[2].Judgement[0, 1] = 1;   //锡
                character[2].Judgement[1, 0] = 1;   //而是
                character[2].Judgement[1, 1] = 2;   //铁
            }
        }

        /// <summary>
        /// 初始化“牧师/骗子/赌棍”类形式1问题的相关属性
        /// </summary>
        public void TypeA_Initialize()
        {
            typeAproperty.lierStatement = -1;
            for (int i = 0; i < 2; i++)
            {
                typeAproperty.gamblerStatement[i] = -1;
                typeAproperty.pastorStatement[i] = -1;
            }
            for (int j = 0; j < 3; j++)
            {
                typeAproperty.personIdentity[j + 1] = -1;
            }
            typeAproperty.score = 0;
        }

        /// <summary>
        /// 在枚举猜测物品之前，将每个人的正确、错误数清零，初始积分恢复为1
        /// </summary>
        public void TypeB_ThingInitialize()
        {
            typeBproperty.score = 1;                    //初始积分为1
            for (int i = 0; i < 4; i++)                 //设置每个人的正确话数、错误话数均为0
            {
                typeBproperty.accuracy[i] = 0;
            }
        }

        /// <summary>
        /// 初始化“正确/错误/部分”类问题的相关属性
        /// </summary>
        public void TypeB_Initialize()
        {
            TypeB_ThingInitialize();
            if (gameProperty.background < 4 && gameProperty.background > 0) //如果为前三个问题背景，人数物数均为3、每人话数为2
            {
                typeBproperty.totalThings = 3;
                typeBproperty.totalGuessperPerson = 2;
            }
            else if (gameProperty.background == 4 || gameProperty.background == 5)      //如果为第四个问题背景，人数物数均为4、每人话数为3
            {
                typeBproperty.totalThings = 4;
                typeBproperty.totalGuessperPerson = 2;
            }
        }

        /// <summary>
        /// 解决“牧师/骗子/赌棍”类形式1（不包含否定句）问题
        /// </summary>
        public void TypeA1_Solve()
        {
            TypeA_Initialize();

            //进行第一轮搜索：如果有人说“我是骗子”，根据规则他只能是赌棍；最多只有一人可以声明“我是骗子”
            for (int i = 0; i < 3; i++)
            {
                if (character[i].statement == 2)
                {
                    character[i].identity = 3;      //将该人身份标记为赌棍
                    typeAproperty.lierStatement = i;//将声明“我是骗子”的人做一个标记
                    break;                          //剪枝：不会有人再声明“我是骗子”了
                }
            }

            //进行第二轮搜索：如果有人说“我是赌棍”（肯定未在第一轮中被解决），那么他是赌棍或者骗子；最多只有两人可以声明“我是赌棍”
            for (int i = 0; i < 3; i++)
            {
                if (character[i].statement == 3)
                {
                    //若有赌棍声明过“我是骗子”，则说“我是赌棍”的人只能是骗子
                    if (typeAproperty.lierStatement != -1)
                    {
                        character[i].identity = 2;              //将该人身份标记为骗子
                        typeAproperty.gamblerStatement[0] = i;  //将声明“我是赌棍”的人做一个标记
                        break;                                  //剪枝：不会有人再声明“我是赌棍”了
                    }
                    //若没有人声明过“我是骗子”：
                    //若有两人声明“我是赌棍”，则他们一人是骗子一人是赌棍；若只有一人声明“我是赌棍”，则他是骗子或赌棍
                    else if (typeAproperty.lierStatement == -1)
                    {
                        if (typeAproperty.gamblerStatement[0] != -1) //若有一人已经声明“我是赌棍”，那么这个首先声明的人是赌棍（根据先说话的人优良准则）
                        {
                            character[typeAproperty.gamblerStatement[0]].identity = 3;  //先声明的人是赌棍
                            character[i].identity = 2;              //后声明的人是骗子
                            typeAproperty.gamblerStatement[1] = i;  //将声明“我是赌棍”的人做一个标记
                            break;                                  //剪枝：不会有人再声明“我是赌棍了”
                        }
                        else if (typeAproperty.gamblerStatement[0] == -1)    //若还没有人声明“我是赌棍”，那么现在这个人的身份存疑
                        {
                            character[i].identity = 4;          //将该人身份标记为赌棍骗子存疑区
                            typeAproperty.gamblerStatement[0] = i;  //将声明“我是赌棍”的人做一个标记
                        }
                    }
                }
            }

            //进行第三轮搜索：如果有人说“我是牧师”（肯定未在前两轮中被解决），那么他啥都可能是；最多能有三人声明“我是牧师”（但本游戏要排除掉三人同时声明“我是牧师”的情况！）
            for (int i = 0; i < 3; i++)
            {
                if (character[i].statement == 1)
                {
                    //若有赌棍声明过“我是骗子”且有骗子声明过“我是赌棍”，那么最后这人就是牧师了
                    if (typeAproperty.lierStatement != -1 && typeAproperty.gamblerStatement[0] != -1)
                    {
                        character[i].identity = 1;              //将该人标记为牧师
                        typeAproperty.pastorStatement[0] = i;   //将声明“我是牧师”的人做一个标记
                        break;                                  //所有人均已判断完毕，剩下的枝全部剪掉
                    }
                    //若有赌棍声明过“我是骗子”且无人声明过“我是赌棍”，则有两人声明“我是牧师”，那么首先声明的人是牧师（根据先说话的人优良准则）
                    if (typeAproperty.lierStatement != -1 && typeAproperty.gamblerStatement[0] == -1)
                    {
                        if (typeAproperty.pastorStatement[0] != -1)     //若有一人已经声明“我是牧师”，那么这个首先声明的人是牧师（根据先说话的人优良准则）
                        {
                            character[i].identity = 2;                  //后声明的人是骗子
                            typeAproperty.pastorStatement[1] = i;       //将声明“我是牧师”的人做一个标记
                            break;                                      //所有人均已判断完毕，剩下的枝全部剪掉
                        }
                        else if (typeAproperty.pastorStatement[0] == -1)    //若还没有人声明“我是牧师”，那么根据先说话的人优良准则，他肯定是牧师的！
                        {
                            character[i].identity = 1;                      //先声明的人是牧师
                            typeAproperty.pastorStatement[0] = i;
                        }
                    }
                    //若无人声明过“我是骗子”且有人（可能是骗子或赌棍）声明过“我是赌棍”，则有一或两人声明“我是牧师”，那么首先声明的人是牧师（根据先说话的人优良准则）
                    if (typeAproperty.lierStatement == -1 && typeAproperty.gamblerStatement[0] != -1)
                    {
                        //若有两人声明“我是赌棍”，那么剩下一人则为牧师，题目完结，没有标记的必要了
                        if (typeAproperty.gamblerStatement[1] != -1)
                        {
                            character[i].identity = 1;
                            break;                                      //所有人均已判断完毕，剩下的枝全部剪掉
                        }
                        //若只有一人声明“我是赌棍”，那么首先声明“我是牧师”的人是牧师。剩下两人可能是赌棍或者骗子，那么首先声明的人是赌棍（根据先说话的人优良准则）
                        else if (typeAproperty.gamblerStatement[1] == -1)
                        {
                            if (typeAproperty.pastorStatement[0] != -1)     //若有一人已经声明“我是牧师”，那么这个首先声明的人是牧师（根据先说话的人优良准则）
                            {
                                character[i].identity = 4;                  //后声明的人是赌棍或骗子
                                typeAproperty.pastorStatement[1] = i;       //将声明“我是牧师”的人做一个标记
                                break;                                      //所有人均已判断完毕，剩下的枝全部剪掉
                            }
                            else if (typeAproperty.pastorStatement[0] == -1)    //若还没有人声明“我是牧师”，那么根据先说话的人优良准则，他肯定是牧师的！
                            {
                                character[i].identity = 1;                      //先声明的人是牧师
                                typeAproperty.pastorStatement[0] = i;
                            }
                        }
                    }
                }
            }

            //进行第四轮搜索：考虑所有存疑的人，先声明的是赌棍
            bool flag = false;          //标记存疑的人是否已有赌棍分配
            for (int i = 0; i < 3; i++)
            {
                if (character[i].identity == 4 && flag == false) //身份存疑，但现在场上还没有赌棍
                {
                    character[i].identity = 3;      //那么他就是赌棍了
                    flag = true;                    //存疑的人已有赌棍分配
                }
                if (character[i].identity == 4 && flag == true) //身份存疑，但现在场上已有赌棍
                {
                    character[i].identity = 2;      //那么他就是骗子了
                }
            }

            TypeA_Initialize();         //完结撒花
        }

        /// <summary>
        /// 解决“牧师/骗子/赌棍”类形式2（包含否定句，不出现重复话语）问题
        /// </summary>
        public void TypeA2_Solve()
        {
            TypeA_Initialize();

            //循环枚举人物角色所有可能的排列情况
            for (int i = 0; i < 3; i++)
            {
                //一次循环：枚举牧师可能的人
                typeAproperty.personIdentity[1] = i;
                for (int j = 0; j < 3 ; j++)
                {
                    //二次循环：枚举骗子可能的人，他不能是一次循环中枚举出的牧师
                    if (j != typeAproperty.personIdentity[1])
                    {
                        typeAproperty.personIdentity[2] = j;
                        for (int k = 0; k < 3; k++)
                        {
                            //三次循环：枚举赌棍可能的人，他不能是一次循环中枚举出的牧师，也不能是二次循环中枚举出的赌棍
                            if (k != typeAproperty.personIdentity[1] && k != typeAproperty.personIdentity[2])
                            {
                                typeAproperty.personIdentity[3] = k;

                                //测试该排列情况是否为可行解
                                typeAproperty.score = 0;
                                //一次测试：牧师只能说出“我是牧师”、“我不是赌棍”、“我不是骗子”
                                if (character[typeAproperty.personIdentity[1]].am == true)
                                {
                                    if (character[typeAproperty.personIdentity[1]].statement == 1)
                                    {
                                        typeAproperty.score++;
                                    }
                                }
                                else if (character[typeAproperty.personIdentity[1]].am == false)
                                {
                                    if (character[typeAproperty.personIdentity[1]].statement == 2 || character[typeAproperty.personIdentity[1]].statement == 3)
                                    {
                                        typeAproperty.score++;
                                    }
                                }
                                //二次测试：骗子只能说出“我是牧师”、“我是赌棍”、“我不是骗子”
                                if (character[typeAproperty.personIdentity[2]].am == true)
                                {
                                    if (character[typeAproperty.personIdentity[2]].statement == 1 || character[typeAproperty.personIdentity[2]].statement == 3)
                                    {
                                        typeAproperty.score++;
                                    }
                                }
                                else if (character[typeAproperty.personIdentity[2]].am == false)
                                {
                                    if (character[typeAproperty.personIdentity[2]].statement == 2)
                                    {
                                        typeAproperty.score++;
                                    }
                                }
                                //计算总分，若总分为2说明为可行解
                                if (typeAproperty.score == 2)
                                {
                                    if (typeAproperty.questioning == true)      //如果正在出题状态
                                    {
                                        typeAproperty.solveSum++;               //可行解总数+1
                                        if (typeAproperty.solveSum == 2)        //若发现已经有不止一个可行解
                                        {
                                            typeAproperty.solveSum = 0;         //废掉这个可行解
                                            goto end;                           //剪去剩下的可行解枝
                                        }
                                    }
                                    else
                                    {
                                        character[typeAproperty.personIdentity[1]].identity = 1;
                                        character[typeAproperty.personIdentity[2]].identity = 2;
                                        character[typeAproperty.personIdentity[3]].identity = 3;
                                        goto end;                              //否则剪去剩下的可行解枝，因为它们不可能是结果了
                                    }
                                }
                            }
                        }
                    }
                }
            }
        end: ;
        }

        /// <summary>
        /// 解决“正确/错误/部分”类问题
        /// </summary>
        public void TypeB_Solve()
        {
            TypeB_Initialize();
            //从1到3（或4）枚举猜测物品是什么
            for (int thing = 1; thing <= typeBproperty.totalThings; thing++)
            {
                TypeB_ThingInitialize();                //在枚举猜测这个物品之前，将每个人的正确、错误数清零，初始积分恢复为1
                for (int i = 0; i < typeBproperty.totalThings; i++)
                {
                    for (int j = 0; j < typeBproperty.totalGuessperPerson; j++)
                    {
                        //i:character从0到typeBproperty.totalThings遍历3/4个人
                        //j:Judgement从[0,0]到[totalGuessperPerson,1]遍历这个人的每句话
                        if (character[i].Judgement[j, 0] == 1)  //如果第i个人的第j句话以“而是”开头
                        {
                            if (character[i].Judgement[j, 1] == thing)  //且这个人“而是”的物品是实际物品，那么这个人说对了
                            {
                                typeBproperty.accuracy[i]++;    //这个人说话正确个数+1
                                //算分
                                if (typeBproperty.accuracy[i] == 1) typeBproperty.score = typeBproperty.score * 5;  //如果是这个人说对的第一句话，总分乘5分
                                else if (typeBproperty.accuracy[i] == 2) typeBproperty.score = typeBproperty.score * 3; //如果是这个人说对的第二句话，总分乘3分
                            }
                        }
                        else if (character[i].Judgement[j, 0] == 2) //如果第i个人的第j句话以“不是”开头
                        {
                            if (character[i].Judgement[j, 1] != thing)  //且这个人“不是”的物品不是实际物品，那么这个人说对了
                            {
                                typeBproperty.accuracy[i]++;    //这个人说话正确个数+1
                                //算分
                                if (typeBproperty.accuracy[i] == 1) typeBproperty.score = typeBproperty.score * 5;  //如果是这个人说对的第一句话，总分乘5分
                                else if (typeBproperty.accuracy[i] == 2) typeBproperty.score = typeBproperty.score * 3; //如果是这个人说对的第二句话，总分乘3分
                            }
                        }
                    }
                }
                //遍历这3/4个人的每句话之后，如果总分符合条件，则说明得出结果
                //前三种背景，总分应为5*3*5=75分
                if (gameProperty.background < 4 && gameProperty.background > 0)
                {
                    if (typeBproperty.score == 75)  //若为75分，说明解出结果符合条件
                    {
                        for (int i = 0; i < 3; i++) //把每个人的属性填满
                        {
                            character[i].accuracy = typeBproperty.accuracy[i];
                        }
                        typeBproperty.thing = thing;//记录实际答案
                        break;                      //剪去剩下的枝，因为它们不可能是符合条件的解了
                    }
                }
                //第四种背景，总分应为(5*3)*5*5=375分
                else if (gameProperty.background == 4 || gameProperty.background == 5)
                {
                    if (typeBproperty.score == 375)
                    {
                        for (int i = 0; i < 4; i++) //把每个人的属性填满
                        {
                            character[i].accuracy = typeBproperty.accuracy[i];
                        }
                        typeBproperty.thing = thing;//记录实际答案
                        if (typeBproperty.questioning==true)    //如果正在出题状态，记录一次
                        {
                            typeBproperty.solveSum++;
                        }
                        else break;                 //如果不在出题状态，剪去剩下的枝，因为它们不可能是符合条件的解了
                    }
                }
            }
            TypeB_Initialize();                     //完结撒花
        }

        /// <summary>
        /// 对随机问题的参数和文字进行设置
        /// </summary>
        public void RandomSetting()
        {
            int randomMemory = 0;               //随机数的存储

            //设置“牧师/骗子/赌棍”类问题的随机参数
            if (gameProperty.type == 1)
            {
                //设置只有肯定句的问题的随机参数
                //算法是：仅生成有且仅有一个解的问题。优点是出题时间短、时间复杂度小、搜索工作量很小，缺点是算法复杂、代码量大。
                if (gameProperty.style == 1)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        character[i].am = true;
                    }
                    character[0].statement = randomizer.Next(3) + 1;    //随机设置第一个人的人物声明
                    if (character[0].statement == 2)                //如果第一个人说自己是骗子，之后不能有人再说自己是骗子
                    {
                        character[1].statement = randomizer.Next(2) + 1;//生成为1声明自己是牧师，生成为2声明自己是赌棍
                        if (character[1].statement == 2) character[1].statement = 3;    //生成为2，改成赌棍声明
                    }
                    else if (character[0].statement != 2)           //如果第一个人没说自己是骗子，那么第二个人可以随意声明
                    {
                        character[1].statement = randomizer.Next(3) + 1;
                    }
                    //如果前两个人分别声明了自己是骗子和赌棍 || 如果前两个人都声明了自己是赌棍，最后一个人只能声明自己是牧师
                    if (character[0].statement + character[1].statement > 4)
                    {
                        character[2].statement = 1;
                    }
                    //如果前两个人分别声明了自己是骗子和牧师，最后一个人可以声明自己是牧师或赌棍
                    else if (character[0].statement + character[1].statement == 3)
                    {
                        character[2].statement = randomizer.Next(2) + 1;//生成为1声明自己是牧师，生成为2声明自己是赌棍
                        if (character[2].statement == 2) character[2].statement = 3;    //生成为2，改成赌棍声明
                    }
                    //如果前两个人分别声明了自己是赌棍和牧师，最后一个人可以随意声明
                    else if (character[0].statement + character[1].statement == 4)
                    {
                        character[2].statement = randomizer.Next(3) + 1;
                    }
                    //如果前两个人都声明了自己是牧师，最后一个人可以声明自己是赌棍或骗子
                    else if (character[0].statement + character[1].statement == 2)
                    {
                        character[2].statement = randomizer.Next(2) + 1;
                        character[2].statement = character[2].statement + 1;
                    }
                }

                //设置有肯定句否定句的问题的随机参数
                //算法是：随机分配每个数，让程序去解，若解出多个结果则重新出题。优点是算法简单，缺点是出题时间不确定，可能会增加时间复杂度。
                else if (gameProperty.style == 2)
                {
                    while (typeAproperty.solveSum == 0)
                    {
                        typeAproperty.questioning = true;
                        typeAproperty.solveSum = 0;
                    loop:for (int m = 0; m < 3; m++)
                        {
                            character[m].statement = randomizer.Next(3) + 1;
                            randomMemory = randomizer.Next(2);
                            if (randomMemory == 0) character[m].am = false;
                            else if (randomMemory == 1) character[m].am = true;
                        }
                    if ((character[0].am == character[1].am && character[0].statement == character[1].statement) ||
                    (character[0].am == character[2].am && character[0].statement == character[2].statement) ||
                    (character[1].am == character[2].am && character[1].statement == character[2].statement)) goto loop;
                    else TypeA2_Solve();                        //求解生成的题
                    }
                    typeAproperty.questioning = false;          //退出出题状态
                    typeAproperty.solveSum = 0;
                }
            }

            //设置“正确/错误/部分”类问题的随机参数
            else if (gameProperty.type == 2)
            {
                int other1thing = 0;
                int other2thing = 0;
                randomMemory = 0;
                TypeBRandomInitialize();
                typeBRandomProperty.thing = randomizer.Next(typeBRandomProperty.totalThings) + 1;       //随机生成一个实际物品
                //将相应的句子置为真/假。实际物品=(这个编号-1)。[]内=0,1,2,3分别对应thing=1,2,3,4。

                //分配每个人说话的正确性。210/2110（其中一个1以3标记）
                typeBRandomProperty.accuracy[0] = randomizer.Next(typeBRandomProperty.totalThings);     //随机生成第一个人的正确性
                typeBRandomProperty.accuNum[typeBRandomProperty.accuracy[0]] = 0;
                //随机生成第二个人的正确性。（若处于初始状态/和第一个人的正确性相同 循环）
                while (typeBRandomProperty.accuracy[1] == -1 || typeBRandomProperty.accuracy[1] == typeBRandomProperty.accuracy[0])
                {
                    typeBRandomProperty.accuracy[1] = randomizer.Next(typeBRandomProperty.totalThings);
                }
                typeBRandomProperty.accuNum[typeBRandomProperty.accuracy[1]] = 1;
                //随机生成第三个人的正确性。（若处于初始状态/和前两个人的正确性相同 循环）
                while (typeBRandomProperty.accuracy[2] == -1 || typeBRandomProperty.accuracy[2] == typeBRandomProperty.accuracy[0] || typeBRandomProperty.accuracy[2] == typeBRandomProperty.accuracy[1])
                {
                    typeBRandomProperty.accuracy[2] = randomizer.Next(typeBRandomProperty.totalThings);
                }
                typeBRandomProperty.accuNum[typeBRandomProperty.accuracy[2]] = 2;

                //三个人和四个人情况的随机参数设置分别采用不同的算法
                //若为前三个背景，共3人，每人2句话。可能的真话3句假话3句。
                //这三个背景的算法是：仅生成有且仅有一个解的问题。优点是出题时间段、时间复杂度小、搜索工作量很小，缺点是算法复杂、代码量大。
                if (gameProperty.background < 4 && gameProperty.background > 0)
                {
                    //第一次分配：分配完全错误者的两句话，第一句为“不是thing”x，第二句为“而是otherthing”x
                    character[typeBRandomProperty.accuNum[0]].Judgement[0, 0] = 2;                          //0.1.1 说对0句话的人的第一句：“不是”
                    character[typeBRandomProperty.accuNum[0]].Judgement[0, 1] = typeBRandomProperty.thing;  //0.1.2 说对0句话的人的第一句：thing
                    character[typeBRandomProperty.accuNum[0]].Judgement[1, 0] = 1;                          //0.2.1 说对0句话的人的第二句：“而是”
                    while (character[typeBRandomProperty.accuNum[0]].Judgement[1, 1] == 0 || character[typeBRandomProperty.accuNum[0]].Judgement[1, 1] == typeBRandomProperty.thing)
                    {
                        //0.2.2 说对0句话的人的第二句：otherthing（若处于初始状态/是thing 循环）
                        character[typeBRandomProperty.accuNum[0]].Judgement[1, 1] = randomizer.Next(typeBRandomProperty.totalThings) + 1;
                    }

                    other1thing = character[typeBRandomProperty.accuNum[0]].Judgement[1, 1];            //第一个人的第二句“是other1thing”
                    for (int i = 1; i <= typeBRandomProperty.totalThings; i++)                          //不是thing不是other1thing的就是other2thing
                    {
                        if (i != other1thing && i != typeBRandomProperty.thing)
                        {
                            other2thing = i;
                        }
                    }

                    //第二次分配：分配对一句者的两句话，*第一句为“不是other1thing”v，第二句为“而是other2thing”x/*第一句为“不是other2thing”v，第二句为“而是other1thing”x/*第一句为“不是other2thing”v，第二句为“不是thing”x/*第一句为“不是thing”x，第二句为“不是other2thing”v
                    character[typeBRandomProperty.accuNum[1]].Judgement[0, 0] = 2;                               //1.1.1 说对1句话的人的第一句：“不是”
                    character[typeBRandomProperty.accuNum[1]].Judgement[0, 1] = randomizer.Next(typeBRandomProperty.totalThings) + 1;   //1.1.2 说对1句话的人的第一句：thing/other2thing
                    //如果第一句为“不是thing”x，第二句只能为“不是other2thing”v
                    if (character[typeBRandomProperty.accuNum[1]].Judgement[0, 1] == typeBRandomProperty.thing)
                    {
                        character[typeBRandomProperty.accuNum[1]].Judgement[1, 0] = 2;  //1.2.1 说对1句话的人的第二句：“不是”
                        character[typeBRandomProperty.accuNum[1]].Judgement[1, 1] = other2thing;
                    }
                    //如果第一句为“不是other2thing”v，第二句可以为“而是other1thing”x或“不是thing”x
                    else if(character[typeBRandomProperty.accuNum[1]].Judgement[0, 1] == other2thing)
                    {
                        character[typeBRandomProperty.accuNum[1]].Judgement[1, 0] = randomizer.Next(2) + 1;        //1.2.1 说对1句话的人的第二句：“而是”/“不是”（随机）
                        //如果为“而是”，则给它分配other1thing
                        if (character[typeBRandomProperty.accuNum[1]].Judgement[1, 0] == 1)
                        {
                            character[typeBRandomProperty.accuNum[1]].Judgement[1, 1] = other1thing;
                        }
                        //如果为“不是”，则直接分配thing
                        else if (character[typeBRandomProperty.accuNum[1]].Judgement[1, 0] == 2)
                        {
                            character[typeBRandomProperty.accuNum[1]].Judgement[1, 1] = typeBRandomProperty.thing;      //1.2.2 说对1句话的人的第二句：thing
                        }
                    }
                    //如果第一句为“不是other1thing”v，第二句可以为“而是other2thing”
                    else if (character[typeBRandomProperty.accuNum[1]].Judgement[0, 1] == other1thing)
                    {
                        character[typeBRandomProperty.accuNum[1]].Judgement[1, 0] = 1;
                        character[typeBRandomProperty.accuNum[1]].Judgement[1, 1] = other2thing;
                    }

                    //第三次分配：分配完全正确者的两句话
                    character[typeBRandomProperty.accuNum[2]].Judgement[0, 0] = 2;                              //2.1.1 说对2句话的人的第一句：“不是”
                    //1、第二个人说出“而是other1thing”的话，那么不能分配“不other1thing”+“是thing”，可以分配（“不other2thing”+“是thing”）/（“不other2thing”+“不other1thing”）/（“不other1thing”+“不other2thing”）
                    if (character[typeBRandomProperty.accuNum[1]].Judgement[1, 0] == 1 && character[typeBRandomProperty.accuNum[1]].Judgement[1, 1] == other1thing)
                    {
                        randomMemory = randomizer.Next(2);                                                          //随机生成0和1的随机数
                        if (randomMemory == 0)                                                          //生成0：2.1.2 other1thing。第一句话为“不other1thing”，第二句话为“不other2thing”
                        {
                            character[typeBRandomProperty.accuNum[2]].Judgement[0, 1] = other1thing;
                            character[typeBRandomProperty.accuNum[2]].Judgement[1, 0] = 2;
                            character[typeBRandomProperty.accuNum[2]].Judgement[1, 1] = other2thing;
                        }
                        else if (randomMemory == 1)                                                     //生成1：2.1.2 other2thing。第一句话为“不other2thing”，第二句话为“是thing”或“不other1thing”
                        {
                            character[typeBRandomProperty.accuNum[2]].Judgement[0, 1] = other2thing;
                            randomMemory = randomizer.Next(2);                                                      //随机生成0和1的随机数
                            if (randomMemory == 0)                                                              //生成0：2.2 第二句话为“是thing”
                            {
                                character[typeBRandomProperty.accuNum[2]].Judgement[1, 0] = 1;
                                character[typeBRandomProperty.accuNum[2]].Judgement[1, 1] = typeBRandomProperty.thing;
                            }
                            else if (randomMemory == 1)                                                         //生成1：2.2 第二句话为“不other1thing”
                            {
                                character[typeBRandomProperty.accuNum[2]].Judgement[1, 0] = 2;
                                character[typeBRandomProperty.accuNum[2]].Judgement[1, 1] = other1thing;
                            }
                        }
                    }
                    //2、如果第二个人说出了“不thing”的话
                    else if (character[typeBRandomProperty.accuNum[1]].Judgement[0, 1] == typeBRandomProperty.thing ||
                             (character[typeBRandomProperty.accuNum[1]].Judgement[1, 0] == 2 && character[typeBRandomProperty.accuNum[1]].Judgement[1, 1] == typeBRandomProperty.thing))
                    {
                        randomMemory = randomizer.Next(2);                              //生成0和1的随机数
                        if (randomMemory == 0)                                          //生成0：2.1.2 other1thing
                        {
                            character[typeBRandomProperty.accuNum[2]].Judgement[0, 1] = other1thing;
                            //如果第二个人另一句是“不other1thing”，不可以分配（“不other1thing”+“是thing”），强制使randomMemory=1
                            if (character[typeBRandomProperty.accuNum[1]].Judgement[0, 1] == other1thing || 
                                (character[typeBRandomProperty.accuNum[1]].Judgement[1, 0] == 2 && character[typeBRandomProperty.accuNum[1]].Judgement[1, 1] == other1thing))
                            {
                                randomMemory = 1;
                            }
                            //如果第二个人另一句是“不other2thing”，可以分配（“不other1thing”+“是thing”）/（“不other2thing”+“是thing”）/（“不other2thing”+“不other1thing”）/（“不other1thing”+“不other2thing”）
                            else if (character[typeBRandomProperty.accuNum[1]].Judgement[0, 1] == other2thing || 
                                    (character[typeBRandomProperty.accuNum[1]].Judgement[1, 0] == 2 && character[typeBRandomProperty.accuNum[1]].Judgement[1, 1] == other2thing))
                            {
                                randomMemory = randomizer.Next(2);   //生成0和1的随机数
                            }
                            if (randomMemory == 0)                                             //生成0：2.2 是thing
                            {
                                character[typeBRandomProperty.accuNum[2]].Judgement[1, 0] = 1;
                                character[typeBRandomProperty.accuNum[2]].Judgement[1, 1] = typeBRandomProperty.thing;
                            }
                            else if (randomMemory == 1)                                        //生成1：2.2 不other2thing
                            {
                                character[typeBRandomProperty.accuNum[2]].Judgement[1, 0] = 2;
                                character[typeBRandomProperty.accuNum[2]].Judgement[1, 1] = other2thing;
                            }
                        }
                        else if (randomMemory == 1)                                     //生成1：2.1.2 other2thing
                        {
                            character[typeBRandomProperty.accuNum[2]].Judgement[0, 1] = other2thing;
                            randomMemory = randomizer.Next(2);
                            if (randomMemory == 0)                                          //生成0:2.2 是thing
                            {
                                character[typeBRandomProperty.accuNum[2]].Judgement[1, 0] = 1;
                                character[typeBRandomProperty.accuNum[2]].Judgement[1, 1] = typeBRandomProperty.thing;
                            }
                            else if (randomMemory == 1)                                     //生成1：2.2 不other1thing
                            {
                                character[typeBRandomProperty.accuNum[2]].Judgement[1, 0] = 2;
                                character[typeBRandomProperty.accuNum[2]].Judgement[1, 1] = other1thing;
                            }
                        }
                    }
                    //3、第二个人说出“而是other2thing”的话，此时只能分配“不other1thing”+“是thing”
                    else if (character[typeBRandomProperty.accuNum[1]].Judgement[1, 0] == 1 && character[typeBRandomProperty.accuNum[1]].Judgement[1, 1] == other2thing)
                    {
                        character[typeBRandomProperty.accuNum[2]].Judgement[0, 0] = 2;
                        character[typeBRandomProperty.accuNum[2]].Judgement[0, 1] = other1thing;
                        character[typeBRandomProperty.accuNum[2]].Judgement[1, 0] = 1;
                        character[typeBRandomProperty.accuNum[2]].Judgement[1, 1] = typeBRandomProperty.thing;
                    }
                }

                //若为第四个背景，共4人，每人2句话。可能的真话4句假话4句。
                //这个背景的算法是：随机分配每个数，让程序去解，若解出多个结果则重新出题。优点是算法简单，缺点是出题时间不确定，可能会增加时间复杂度。
                else if (gameProperty.background == 4 || gameProperty.background == 5)
                {
                    if (gameProperty.background == 4) typeBproperty.difficulty = 6;
                    else if (gameProperty.background == 5) typeBproperty.difficulty = 4;
                    typeBproperty.questioning = true;
                    typeBproperty.solveSum = 0;
                    //如果正确的解数不是1个（无解或多解），且不满足格式要求和难度要求，再生成一道题。
                    //为了增加难度，“不是而是”至少有三个
                    while (typeBproperty.solveSum != 1 ||
                        character[0].Judgement[0, 0] == 1 || character[1].Judgement[0, 0] == 1 || character[2].Judgement[0, 0] == 1 || character[3].Judgement[0, 0] == 1 ||
                        character[0].Judgement[0, 1] == character[0].Judgement[1, 1] || character[1].Judgement[0, 1] == character[1].Judgement[1, 1] || character[2].Judgement[0, 1] == character[2].Judgement[1, 1] || character[3].Judgement[0, 1] == character[3].Judgement[1, 1] ||
                        character[0].Judgement[1, 0] + character[1].Judgement[1, 0] + character[2].Judgement[1, 0] + character[3].Judgement[1, 0] > typeBproperty.difficulty) 
                    {
                        typeBproperty.questioning = true;
                        typeBproperty.solveSum = 0;
                        for (int m = 0; m < 4; m++)
                        {
                            for (int n = 0; n < 2; n++)
                            {
                                character[m].Judgement[n, 0] = randomizer.Next(2) + 1;
                                character[m].Judgement[n, 1] = randomizer.Next(4) + 1;
                            }
                        }
                        TypeB_Solve();                          //求解生成的题
                    }
                    typeBproperty.questioning = false;          //退出出题状态
                }
            }
        }

        /// <summary>
        /// 在时间终了或点击计算/提交按钮后显示答案
        /// </summary>
        public void AnswerDisplay()
        {
            //显示“牧师/骗子/赌棍”类问题的问题答案
            if (gameProperty.type == 1)
            {
                //显示只有肯定句的问题的问题答案
                if (gameProperty.style == 1)
                {
                    TypeA1_Solve();
                    if (character[0].identity == 1) identityLabelA.Text = "牧师";
                    else if (character[0].identity == 2) identityLabelA.Text = "骗子";
                    else if (character[0].identity == 3) identityLabelA.Text = "赌棍";
                    if (character[1].identity == 1) identityLabelB.Text = "牧师";
                    else if (character[1].identity == 2) identityLabelB.Text = "骗子";
                    else if (character[1].identity == 3) identityLabelB.Text = "赌棍";
                    if (character[2].identity == 1) identityLabelC.Text = "牧师";
                    else if (character[2].identity == 2) identityLabelC.Text = "骗子";
                    else if (character[2].identity == 3) identityLabelC.Text = "赌棍";
                }
                //显示有肯定句否定句的问题的问题答案
                else if (gameProperty.style == 2)
                {
                    TypeA2_Solve();
                    if (character[0].identity == 1) identityLabelA.Text = "牧师";
                    else if (character[0].identity == 2) identityLabelA.Text = "骗子";
                    else if (character[0].identity == 3) identityLabelA.Text = "赌棍";
                    if (character[1].identity == 1) identityLabelB.Text = "牧师";
                    else if (character[1].identity == 2) identityLabelB.Text = "骗子";
                    else if (character[1].identity == 3) identityLabelB.Text = "赌棍";
                    if (character[2].identity == 1) identityLabelC.Text = "牧师";
                    else if (character[2].identity == 2) identityLabelC.Text = "骗子";
                    else if (character[2].identity == 3) identityLabelC.Text = "赌棍";
                }
            }

            //显示“正确/错误/部分”类问题的问题答案
            else if (gameProperty.type == 2)
            {
                TypeB_Solve();
                //前三种背景，共有三个人，每个人有两句话
                if (character[0].accuracy == 0) identityLabelA.Text = "完全说错";
                else if (character[0].accuracy == 1) identityLabelA.Text = "只说对了一半";
                else if (character[0].accuracy == 2) identityLabelA.Text = "完全正确";
                if (character[1].accuracy == 0) identityLabelB.Text = "完全说错";
                else if (character[1].accuracy == 1) identityLabelB.Text = "只说对了一半";
                else if (character[1].accuracy == 2) identityLabelB.Text = "完全正确";
                if (character[2].accuracy == 0) identityLabelC.Text = "完全说错";
                else if (character[2].accuracy == 1) identityLabelC.Text = "只说对了一半";
                else if (character[2].accuracy == 2) identityLabelC.Text = "完全正确";
                //第四种背景，共有四个人，每个人有两句话
                if (gameProperty.background == 4 || gameProperty.background == 5)
                {
                    if (character[3].accuracy == 0) identityLabelD.Text = "完全说错";
                    else if (character[3].accuracy == 1) identityLabelD.Text = "只说对了一半";
                    else if (character[3].accuracy == 2) identityLabelD.Text = "完全正确";
                }
                paraAnswerRename();
            }
        }

        /// <summary>
        /// 在计算机解题模式下弹出对话框显示提示信息和答案
        /// </summary>
        public void MessageDisplay()
        {
            if (gameProperty.type == 1)
            {
                MessageBox.Show("看我一下子就算出来了！" + "\n"
                    + para.name[0] + "是" + identityLabelA.Text + "，"
                    + para.name[1] + "是" + identityLabelB.Text + "，"
                    + para.name[2] + "是" + identityLabelC.Text + "。", "计算完毕！");
            }
            else if (gameProperty.type == 2)
            {
                if (gameProperty.background < 4 && gameProperty.background > 0)
                {
                    MessageBox.Show("看我一下子就算出来了！" + "\n"
                   + para.name[0] + identityLabelA.Text + "，"
                   + para.name[1] + identityLabelB.Text + "，"
                   + para.name[2] + identityLabelC.Text + "。" + "\n"
                   + para.itIs + para.answer + "。", "计算完毕！");
                }
                else if (gameProperty.background == 4 || gameProperty.background == 5)
                {
                    MessageBox.Show("看我一下子就算出来了！" + "\n"
                    + para.name[0] + identityLabelA.Text + "，"
                    + para.name[1] + identityLabelB.Text + "，"
                    + para.name[2] + identityLabelC.Text + "，"
                    + para.name[3] + identityLabelD.Text + "。" + "\n"
                   + para.itIs + para.answer + "。", "计算完毕！");
                }
            }
        }
        
        /// <summary>
        /// 在人工解题模式下确认提交的答案是否正确，并弹出对话框显示提示信息和答案
        /// </summary>
        public void AnswerCheck()
        {
            if (gameProperty.type == 1)
            {
                if (identityBoxA.Text == identityLabelA.Text && identityBoxB.Text == identityLabelB.Text && identityBoxC.Text == identityLabelC.Text)
                {
                    MessageBox.Show("欧尼酱，好腻害~~~", "恭喜你！全部答对！");
                }
                else MessageBox.Show("笨蛋欧尼酱，做错了！" + "\n"
                        + para.name[0] + "是" + identityLabelA.Text + "，"
                        + para.name[1] + "是" + identityLabelB.Text + "，"
                        + para.name[2] + "是" + identityLabelC.Text + "。", "很遗憾！");
            }
            else if (gameProperty.type == 2)
            {
                if (gameProperty.background < 4 && gameProperty.background > 0)
                {
                    if (identityBoxA.Text == identityLabelA.Text && identityBoxB.Text == identityLabelB.Text && identityBoxC.Text == identityLabelC.Text)
                    {
                        MessageBox.Show("欧尼酱，好腻害~~~" + "\n"
                            + para.itIs + para.answer + "。", "恭喜你！全部答对！");
                    }
                    else MessageBox.Show("笨蛋欧尼酱，做错了！" + "\n"
                            + para.name[0] + identityLabelA.Text + "，"
                            + para.name[1] + identityLabelB.Text + "，"
                            + para.name[2] + identityLabelC.Text + "。" + "\n"
                            + para.itIs + para.answer + "。", "很遗憾！");
                }
                else if (gameProperty.background == 4 || gameProperty.background == 5)
                {
                    if (identityBoxA.Text == identityLabelA.Text && identityBoxB.Text == identityLabelB.Text && identityBoxC.Text == identityLabelC.Text && identityBoxD.Text == identityLabelD.Text)
                    {
                        MessageBox.Show("欧尼酱，好腻害~~~" + "\n"
                            + para.itIs + para.answer + "。", "恭喜你！全部答对！");
                    }
                    else MessageBox.Show("笨蛋欧尼酱，做错了！" + "\n"
                            + para.name[0] + identityLabelA.Text + "，"
                            + para.name[1] + identityLabelB.Text + "，"
                            + para.name[2] + identityLabelC.Text + "，"
                            + para.name[3] + identityLabelD.Text + "。" + "\n"
                            + para.itIs + para.answer + "。", "很遗憾！");
                }
            }
        }

        /********************************以上为游戏函数段********************************/
        /******************************以下为设计元素处理段******************************/

        public Form1()
        {
            InitializeComponent();
            label1.Parent = pictureBox2;
            label2.Parent = pictureBox2;
            label3.Parent = pictureBox2;
            label4.Parent = pictureBox2;
            timeLabel.Parent = pictureBox2;
            timeBox.Parent = pictureBox2;
            questionLabel.Parent = pictureBox2;
            dialogLabelA.Parent = pictureBox2;
            dialogLabelB.Parent = pictureBox2;
            dialogLabelC.Parent = pictureBox2;
            dialogLabelD.Parent = pictureBox2;
            dialogBox1.Parent = pictureBox2;
            dialogBox2.Parent = pictureBox2;
            dialogBox3.Parent = pictureBox2;
            dialogBox4.Parent = pictureBox2;
            identityLabelA.Parent = pictureBox2;
            identityLabelB.Parent = pictureBox2;
            identityLabelC.Parent = pictureBox2;
            identityLabelD.Parent = pictureBox2;
            pictureBox1.Parent = pictureBox2;
            groupBox1.Parent = pictureBox2;
            groupBox2.Parent = pictureBox2;
            groupBox3.Parent = pictureBox2;
            groupBox4.Parent = pictureBox2;
            groupBox5.Parent = pictureBox2;
            LinZikun.Parent = pictureBox2;
            this.dialogBox4.Location = new Point(555, 220);
            this.dialogLabelD.Location = new Point(593, 238);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (gameProperty.mode == 2)
            {
                if (CheckTheAnswer == true)
                {
                    timer.Stop();
                    AnswerCheck();
                    CheckTheAnswer = false;
                }
                else if (timeLeft > 0)
                {
                    timeLeft--;
                    if (timeLeft > 1) timeLabel.Text = timeLeft + "  seconds";
                    else if (timeLeft == 1 || timeLeft == 0) timeLabel.Text = timeLeft + "  second";
                }
                else
                {
                    timer.Stop();
                    timeLabel.Text = "Time's up!";
                    AnswerDisplay();
                    if (gameProperty.type == 1)
                    {
                        MessageBox.Show("欧尼酱，你太慢了啦！" + "\n"
                            + para.name[0] + "是" + identityLabelA.Text + "，"
                            + para.name[1] + "是" + identityLabelB.Text + "，"
                            + para.name[2] + "是" + identityLabelC.Text + "。", "午时已到！");
                    }
                    else if (gameProperty.type == 2)
                    {
                        if (gameProperty.background < 4 && gameProperty.background > 0)
                        {
                            MessageBox.Show("欧尼酱，你太慢了啦！" + "\n"
                                + para.name[0] + identityLabelA.Text + "，"
                                + para.name[1] + identityLabelB.Text + "，"
                                + para.name[2] + identityLabelC.Text + "。" + "\n"
                                + para.itIs + para.answer + "。", "午时已到！");
                        }
                        else if (gameProperty.background == 4 || gameProperty.background == 5)
                        {
                            MessageBox.Show("欧尼酱，你太慢了啦！" + "\n"
                                + para.name[0] + identityLabelA.Text + "，"
                                + para.name[1] + identityLabelB.Text + "，"
                                + para.name[2] + identityLabelC.Text + "，"
                                + para.name[3] + identityLabelD.Text + "。" + "\n"
                                + para.itIs + para.answer + "。", "午时已到！");
                        }
                    }
                    submitButton.Enabled = false;
                }
            }
        }

        private void machineMode_CheckedChanged(object sender, EventArgs e)
        {
            //如果选中了“计算机解题”方式
            if (machineMode.Checked == true)
            {
                gameProperty.mode = 1;          //修改属性中模式代码为1
                submitButton.Text = "计算答案"; //修改提交键文本
                identityBoxA.Enabled = false;
                identityBoxB.Enabled = false;
                identityBoxC.Enabled = false;
                timeBox.Enabled = false;
            }
            //否则选中了“人工解题”方式
            else
            {
                timer.Stop();
                gameProperty.mode = 2;          //修改属性中模式代码为2
                submitButton.Text = "提交答案"; //修改提交键文本
                identityBoxA.Enabled = true;
                identityBoxB.Enabled = true;
                identityBoxC.Enabled = true;
                timeBox.Enabled = true;
                IdentityBoxLabelChange();       //身份选择和真实身份标签初始化
                submitButton.Enabled = false;
            }
        }

        private void typeA_CheckedChanged(object sender, EventArgs e)
        {
            //如果选中了“牧师/骗子/赌棍”类问题
            if (typeA.Checked == true)
            {
                gameProperty.type = 1;  //修改属性中类型代码为1
                //此时问题风格适用，启用选择
                amOnlyStyle.Enabled = true;
                if(defaultQuestion.Checked==true)
                {
                    amOnlyStyle.Checked = true;
                    amNotStyle.Enabled = false;
                }
                else
                {
                    amNotStyle.Enabled = true;
                }
                //此时问题背景不适用，不启用选择
                metalBackground.Enabled = false;
                courseBackground.Enabled = false;
                coffeeBackground.Enabled = false;
                testBackground.Enabled = false;
                testHardBackground.Enabled = false;
            }

            //否则选中了“正确/错误/部分”类问题
            else
            {
                gameProperty.type = 2;  //修改属性中类型代码为2
                //此时问题风格不适用，不启用选择
                amOnlyStyle.Enabled = false;
                amNotStyle.Enabled = false;
                //此时问题背景适用，启用选择
                metalBackground.Enabled = true;
                if (defaultQuestion.Checked == true)
                {
                    metalBackground.Checked = true;
                    courseBackground.Enabled = false;
                    coffeeBackground.Enabled = false;
                    testBackground.Enabled = false;
                    testHardBackground.Enabled = false;
                }
                else
                {
                    courseBackground.Enabled = true;
                    coffeeBackground.Enabled = true;
                    testBackground.Enabled = true;
                    testHardBackground.Enabled = true;
                }
            }
            IdentityBoxLabelChange();       //身份选择和真实身份标签初始化
        }

        private void defaultQuestion_CheckedChanged(object sender, EventArgs e)
        {
            //如果选中了“默认题目”出题方式
            if (defaultQuestion.Checked == true)
            {
                gameProperty.set = 1;  //修改属性中出题方式代码为1
                if (typeA.Checked == true)
                {
                    amOnlyStyle.Checked = true; 
                    amNotStyle.Enabled = false;
                }
                if (typeB.Checked == true)
                {
                    metalBackground.Checked = true;
                    courseBackground.Enabled = false;
                    coffeeBackground.Enabled = false;
                    testBackground.Enabled = false;
                    testHardBackground.Enabled = false;
                }
            }
            //否则选中了“随机出题”出题方式
            else
            {
                gameProperty.set = 2;  //修改属性中出题方式代码为2
                if (typeA.Checked == true)
                {
                    amNotStyle.Enabled = true;
                }
                if (typeB.Checked == true)
                {
                    courseBackground.Enabled = true;
                    coffeeBackground.Enabled = true;
                    testBackground.Enabled = true;
                    testHardBackground.Enabled = true;
                }
            }
            IdentityBoxLabelChange();       //身份选择和真实身份标签初始化
        }

        private void amOnlyStyle_CheckedChanged(object sender, EventArgs e)
        {
            //如果选中了“只有肯定句”形式的题目
            if (amOnlyStyle.Checked == true)
            {
                gameProperty.style = 1;
            }
            else
            {
                gameProperty.style = 2;
            }
        }

        private void metalBackground_CheckedChanged(object sender, EventArgs e)
        {
            if (metalBackground.Checked == true)
            {
                gameProperty.background = 1;   //修改属性中问题背景代码为1
            }
            paraAnswerRename();
            IdentityBoxLabelChange();       //身份选择和真实身份标签初始化
        }

        private void courseBackground_CheckedChanged(object sender, EventArgs e)
        {
            if (courseBackground.Checked == true)
            {
                gameProperty.background = 2;    //修改属性中问题背景代码为2
            }
            paraAnswerRename();
            IdentityBoxLabelChange();           //身份选择和真实身份标签初始化
        }

        private void coffeeBackground_CheckedChanged(object sender, EventArgs e)
        {
            if (coffeeBackground.Checked == true)
            {
                gameProperty.background = 3;  //修改属性中问题背景代码为3
            } 
            paraAnswerRename();
            IdentityBoxLabelChange();       //身份选择和真实身份标签初始化
        }

        private void testBackground_CheckedChanged(object sender, EventArgs e)
        {
            if (testBackground.Checked == true)
            {
                gameProperty.background = 4;    //修改属性中问题背景代码为4
            }
            paraAnswerRename();
            IdentityBoxLabelChange();       //身份选择和真实身份标签初始化
        }

        private void testHardBackground_CheckedChanged(object sender, EventArgs e)
        {
            if (testHardBackground.Checked == true)
            {
                gameProperty.background = 5;    //修改属性中问题背景代码为5
            }
            paraAnswerRename();
            IdentityBoxLabelChange();       //身份选择和真实身份标签初始化
        }

        private void quizButton_Click(object sender, EventArgs e)
        {
            UIMatch();
            IdentityBoxLabelChange();
            if (gameProperty.type == 1)
            {
                identityLabelA.Text = "真实身份";
                identityLabelB.Text = "真实身份";
                identityLabelC.Text = "真实身份";
            }
            else if (gameProperty.type == 2)
            {
                identityLabelA.Text = "答案";
                identityLabelB.Text = "答案";
                identityLabelC.Text = "答案";
                identityLabelD.Text = "答案";
            }
            if (gameProperty.mode == 2)
            {
                timeLeft = (int)timeBox.Value;
                timeLabel.Text = timeLeft + "  seconds";
                timer.Start();
            }
            if (gameProperty.set == 1) DefaultSetting();
            else if (gameProperty.set == 2) RandomSetting();
            if (gameProperty.type == 1) StatementMatch();
            else if (gameProperty.type == 2) GuessMatch();
            ParagraphTrans();
            questionLabel.Text = question;
            dialogLabelA.Text = Quote[0];
            dialogLabelB.Text = Quote[1];
            dialogLabelC.Text = Quote[2];
            dialogLabelD.Text = Quote[3];
            submitButton.Enabled = true;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            AnswerDisplay();
            if (gameProperty.mode == 1) MessageDisplay();
            else if (gameProperty.mode == 2) CheckTheAnswer = true;
            submitButton.Enabled = false;
        }
    }
}
