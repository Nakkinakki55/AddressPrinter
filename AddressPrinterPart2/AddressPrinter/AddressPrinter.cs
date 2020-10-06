using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace AddressPrinter
{
    public partial class AddressPrinter : Form
    {
        //郵便番号を格納するための変数
        public string strZipCodeForm;
        public AddressPrinter()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddressPrinter_Load(object sender, EventArgs e)
        {
            try
            {
                //宛名コンボボックスにデータを追加する
                combAtenaKeisyou.Items.Add("様");
                combAtenaKeisyou.Items.Add("先生");
                combAtenaKeisyou.Items.Add("殿");
                combAtenaKeisyou.Items.Add("御中");
                combAtenaKeisyou.Items.Add("");

                //宛名コンボボックスの初期表示
                combAtenaKeisyou.SelectedIndex = 0;

                //所属先コンボボックスにデータを追加する
                combSyozokusakiKEisyouAtena.Items.Add("");
                combSyozokusakiKEisyouAtena.Items.Add("様方");
                combSyozokusakiKEisyouAtena.Items.Add("気付");

                //所属先コンボボックスにデータを初期表示
                combSyozokusakiKEisyouAtena.SelectedIndex = 0;

                //最大サイズと最小サイズを現在のサイズに設定する
                this.MaximumSize = this.Size;
                this.MinimumSize = this.Size;
            }
            catch
            {
                MessageBox.Show("予期せぬエラーです。",
                        "エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                return;
            }
        }

        /// <summary>
        /// 住所検索ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKennsakuAtena_Click(object sender, EventArgs e)
        {
            try
            {
                //参考文献　https://noarts.net/archives/2744

                //インターネットに接続されていない場合に表示されるメッセージ
                if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    MessageBox.Show("インターネットを接続してください。",
                            "エラー",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                    return;
                }

                //検索したい郵便番号を文字型変数に代入
                strZipCodeForm = txtYubinnbanngouAtena.Text;

                //郵便番号を半角に変換
                strZipCodeForm = Microsoft.VisualBasic.Strings.StrConv(strZipCodeForm, Microsoft.VisualBasic.VbStrConv.Narrow, 0x411);


                //住所検索用のAPIのURL
                string url = "https://zipcloud.ibsnet.co.jp/api/search?zipcode=" + strZipCodeForm;

                using (var webClient = new System.Net.WebClient())
                {
                    // エンコーディングをUTF-8にしておく（取得してからEncoding変えてもパースできなかった）
                    webClient.Encoding = System.Text.Encoding.UTF8;

                    // JSONのテキストを取得
                    string jsonStr = webClient.DownloadString(url);

                    // JSON文字列をオブジェクトに変換
                    Rootobject obj = JsonSerializer.Deserialize<Rootobject>(jsonStr);


                    // 正常にデータ取得できたか確認
                    if (obj.status == 200 && obj.results != null)
                    {
                        //検索した郵便番号に当てはまる住所が一つだけなら、そのまま住所を記載する
                        if (obj.results.Length == 1)
                        {
                            string strKen = (obj.results[0].address1).ToString();
                            string strSityousonn = (obj.results[0].address2).ToString();
                            string strZyuusyo = (obj.results[0].address3).ToString();

                            txtZyuusyoAtena.Text = strKen + strSityousonn + strZyuusyo;

                            return;
                        }

                        //検索した郵便番号に当てはまる住所が複数ならコンボボックスを表示する
                        if (obj.results.Length > 1)
                        {
                            List<string> listAddAddress = new List<string>();

                            for (int i = 0; i < obj.results.Length; i++)
                            {
                                string strKen = (obj.results[i].address1).ToString();
                                string strSityousonn = (obj.results[i].address2).ToString();
                                string strZyuusyo = (obj.results[i].address3).ToString();

                                listAddAddress.Add(strKen + strSityousonn + strZyuusyo);
                            }

                            NyuuryokuKouho FormNyuu = new NyuuryokuKouho(listAddAddress);

                            //住所を複数を表示するフォームを呼ぶ
                            //ここではモーダルダイアログボックスとして表示する
                            // フォームの初期表示位置を親フォームの中央に設定
                            FormNyuu.StartPosition = FormStartPosition.CenterParent;

                            //オーナーウィンドウにthisを指定する
                            FormNyuu.ShowDialog(this);

                            //フォームが必要なくなったところで、Disposeを呼び出す
                            FormNyuu.Dispose();

                            //選択した住所を記載する
                            txtZyuusyoAtena.Text = FormNyuu.strSend;
                        }
                    }
                    //もし存在しない住所を記載した場合はエラーメッセージを表示する
                    else
                    {
                        MessageBox.Show("存在しない郵便番号です。",
                            "エラー",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("予期せぬエラーです。",
                        "エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                return;
            }
        }

        
        
        /// <summary>
        /// 印刷ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsatu_Click(object sender, EventArgs e)
        {
            try
            {
                //郵便番号を入力する入力欄に7文字未満の文字しか入力されていない場合
                if ((txtYubinnbanngouAtena.Text).Length < 7)
                {
                    MessageBox.Show("7文字以上の文字を入力してください。",
                            "エラー",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                    return;
                }

                //住所入力欄が空白の場合、エラーメッセージを表示する
                if (String.IsNullOrEmpty(txtZyuusyoAtena.Text))
                {
                    MessageBox.Show("住所入力欄が空白です。",
                            "エラー",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                    return;
                }

                //宛名入力欄が空白の場合、エラーメッセージを表示する
                if (String.IsNullOrEmpty(txtAtenaName.Text))
                {
                    MessageBox.Show("宛名入力欄が空白です。",
                            "エラー",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                    return;
                }

                //PrintDocumentオブジェクトの作成
                System.Drawing.Printing.PrintDocument pd =
                    new System.Drawing.Printing.PrintDocument();
                //PrintPageイベントハンドラの追加
                pd.PrintPage +=
                    new System.Drawing.Printing.PrintPageEventHandler(pd_PrintPage);

                //PrintDialogクラスの作成
                PrintDialog pdlg = new PrintDialog();

                //PrintDocumentを指定
                pdlg.Document = pd;

                PaperKind pPaperSz;
                pPaperSz = PaperKind.JapanesePostcard;

                //印刷の選択ダイアログを表示する
                if (pdlg.ShowDialog() == DialogResult.OK)
                {
                    //OKがクリックされた時は印刷する
                    pd.Print();
                }
            }
            catch
            {
                MessageBox.Show("予期せぬエラーです。",
                        "エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                return;
            }
        }

        /// <summary>
        /// 印刷プレビューボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsatsuPreview_Click(object sender, EventArgs e)
        {

            try
            {
                if ((txtYubinnbanngouAtena.Text).Length < 7)
                {
                    MessageBox.Show("7文字以上の文字を入力してください。",
                            "エラー",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                    return;
                }

                //住所入力欄が空白の場合、エラーメッセージを表示する
                if (String.IsNullOrEmpty(txtZyuusyoAtena.Text))
                {
                    MessageBox.Show("住所入力欄が空白です。",
                            "エラー",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                    return;
                }

                //宛名入力欄が空白の場合、エラーメッセージを表示する
                if (String.IsNullOrEmpty(txtAtenaName.Text))
                {
                    MessageBox.Show("宛名入力欄が空白です。",
                            "エラー",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                    return;
                }


                PaperKind pPaperSz;
                pPaperSz = PaperKind.JapanesePostcard;


                //PrintDocumentオブジェクトの作成
                System.Drawing.Printing.PrintDocument pd =
                    new System.Drawing.Printing.PrintDocument();
                //PrintPageイベントハンドラの追加
                pd.PrintPage +=
                    new System.Drawing.Printing.PrintPageEventHandler(pd_PrintPage);

                //PrintPreviewDialogオブジェクトの作成
                PrintPreviewDialog ppd = new PrintPreviewDialog();
                //プレビューするPrintDocumentを設定
                ppd.Document = pd;
                //印刷プレビューダイアログを表示する
                ppd.ShowDialog();
            }
            catch
            {
                MessageBox.Show("予期せぬエラーです。",
                        "エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                return;
            }
        }

        /// <summary>
        /// 住所印刷メソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //郵便番号を変数に代入する
            strZipCodeForm = txtYubinnbanngouAtena.Text;

            //郵便番号を格納する変数を半角に変換する
            strZipCodeForm = Microsoft.VisualBasic.Strings.StrConv(strZipCodeForm, Microsoft.VisualBasic.VbStrConv.Narrow, 0x411);

            //郵便番号にハイフンを入れる
            if (!strZipCodeForm.Contains('-'))
            {
                strZipCodeForm = strZipCodeForm.Insert(3, "-");
            }

            //住所印刷メソッドを呼ぶ
            draw(e, strZipCodeForm, txtZyuusyoAtena.Text, txtTatemonoAtena.Text
                , txtSyozokusakiAtena.Text + combSyozokusakiKEisyouAtena.Text
                , txtAtenaName.Text + combAtenaKeisyou.Text);
        }


        /// <summary>
        /// 住所印刷メソッド
        /// </summary>
        /// <param name="e"></param>
        /// <param name="strAddress"></param>
        /// <param name="strMansion"></param>
        /// <param name="strTatemono"></param>
        /// <param name="strSyozokusaki"></param>
        /// <param name="strAtena"></param>
        void draw(EventArgs e,string strAddress,string strMansion,string strTatemono
            ,string strSyozokusaki,string strAtena)
        {
            
            int intDisPlayXLeftMargin = 10; // 表示の左のマージン
            int intDisPlayYUpperMargin = 8;  // 表示の上のマージン

            double doubleScaleFactor = 3.937;    // scale factor: 1mm = 0.03937 inch
            int intUpDownMargin = 3;  // 上下、左右のマージン
            int intAvgScaleFactor = 394 - intUpDownMargin * 8;       // 3.937を4とした
            int intTopSpace = 47 - 14;  // 12.0 * 3.937 = 47.244
            int intWeight = 22, intHeight = 31;// 5.7*3.937=22.44, 8*3.937=31.496
            double DoubleLeftHigh = 44.3 - 5.5;
            double doubleLeftLow = 65.9 - 5.5;

            bool blnFPaint = e is PaintEventArgs;
            Graphics grap = blnFPaint ? ((PaintEventArgs)e).Graphics
                                : ((PrintPageEventArgs)e).Graphics;

            StringFormat sfVert;
            sfVert = new StringFormat();
            sfVert.FormatFlags = StringFormatFlags.DirectionVertical
                            | StringFormatFlags.DirectionRightToLeft;      // 右から

            //住所、
            string[][] address = {new string[]{ strAddress, strMansion,strTatemono, strSyozokusaki,strAtena },};

            string zipcode = address[0][0];

            Font fontAtenaMoji = new Font("ＭＳ ゴシック", 18, FontStyle.Regular);
            StringFormat stfAA = new StringFormat();

            //郵便番号の先頭三文字を印字する
            for (int n = 0; n < 3; n++)
            {
                int intLeftPrintAtenaFront = (int)((DoubleLeftHigh + n * 7.0) * doubleScaleFactor + 0.5);
                if (blnFPaint) grap.DrawRectangle(Pens.Red, intDisPlayXLeftMargin + intLeftPrintAtenaFront, intDisPlayYUpperMargin + intTopSpace, intWeight, intHeight);
                grap.DrawString(zipcode.Substring(n, 1), fontAtenaMoji, Brushes.Black,
                            intLeftPrintAtenaFront + 12, intDisPlayYUpperMargin + intTopSpace + 3, stfAA);
            }

            //郵便番号の後ろ4文字を印字する
            for (int n = 0; n < 4; n++)
            {
                int intLeftPrintBack = (int)((doubleLeftLow + n * 6.7) * doubleScaleFactor + 0.5);
                if (blnFPaint) grap.DrawRectangle(Pens.Pink, intDisPlayXLeftMargin + intLeftPrintBack, intDisPlayYUpperMargin + intTopSpace, intWeight, intHeight);
                grap.DrawString(zipcode.Substring(n + 4, 1), fontAtenaMoji, Brushes.Black, intLeftPrintBack + 12, intDisPlayYUpperMargin + intTopSpace + 3, stfAA);
            }

            // 住所と宛名
            Font fntAddr;

            //もし住所が20文字以上なら文字の大きさを変更するする
            if (txtZyuusyoAtena.Text.Length >= 20)
            {
                //住所を印字するフォント 
                fntAddr = new Font("@有澤行書", 15, FontStyle.Regular);
            }
            else
            {
                //住所を印字するフォント
                fntAddr = new Font("@有澤行書", 17, FontStyle.Regular);
            }

            //宛名を印字するフォント
            Font fntName = new Font("@有澤行書", 25, FontStyle.Regular);


            Size sz2 = TextRenderer.MeasureText(grap, address[0][2], fntAddr);
            Size sz3 = TextRenderer.MeasureText(grap, address[0][3], fntAddr);

            //住所、マンション名、部屋番号、所属先を印字する場所
            int intAddrressPrintPlace = address[0][3].Length == 0 ? intAvgScaleFactor - 30 : intAvgScaleFactor - 25;
            int intMansionPrintPlace = address[0][3].Length == 0 ? intAvgScaleFactor - 70 : intAvgScaleFactor - 60;
            int intSyozokusakiPrintPlace = address[0][3].Length == 0 ? intAvgScaleFactor - 110 : intAvgScaleFactor - 120;

            //もし住所が20文字以上なら改行する
            if (txtZyuusyoAtena.Text.Length >= 20)
            {
                grap.DrawString(address[0][1].Substring(0,19), fntAddr, Brushes.Black, intAddrressPrintPlace, 80, sfVert);
                grap.DrawString(address[0][1].Substring(19, address[0][1].Length-19)+"　"+address[0][2], fntAddr, Brushes.Black, intMansionPrintPlace, 85, sfVert);
            }
            else
            {
                grap.DrawString(address[0][1], fntAddr, Brushes.Black, intAddrressPrintPlace, 80, sfVert);
                grap.DrawString(address[0][2], fntAddr, Brushes.Black, intMansionPrintPlace, 200, sfVert);
            }

            //宛名を印字する
            grap.DrawString(address[0][3], fntAddr, Brushes.Black, intSyozokusakiPrintPlace, 100, sfVert);
            string name = address[0][4];
            for (int n = 0; n < name.Length; n++)
            {
                grap.DrawString(name.Substring(n, 1), fntName, Brushes.Black,
                            intAvgScaleFactor - 150, 120 + n * 50, sfVert);
            }
            
        }

       
    }


    /// <summary>
    /// JSON文字列をクラスにする
    /// </summary>
    public class Rootobject
    {
        public object message { get; set; }
        public Result[] results { get; set; }
        public int status { get; set; }
    }

    public class Result
    {
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string kana1 { get; set; }
        public string kana2 { get; set; }
        public string kana3 { get; set; }
        public string prefcode { get; set; }
        public string zipcode { get; set; }
    }

}

