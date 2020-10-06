using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AddressPrinter
{
    public partial class NyuuryokuKouho : Form
    {
        //親画面に引き渡すための変数
        public string strSend = string.Empty;

        private List<string> listAddAddress = new List<string>();
        public NyuuryokuKouho(IEnumerable<string> enumerable)
        {
            InitializeComponent();
            listAddAddress = enumerable.ToList();

        }


        /// <summary>
        /// フォームロードインベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Nyuuryokukouho_Load(object sender, EventArgs e)
        {
            
            //複数の住所をコンボボックスに表示する
            for(int i=0;i< listAddAddress.Count;i++)
            {
                comboBox1.Items.Add(listAddAddress[i]);
            }

            // 読み取り専用（テキストボックスは編集不可）にする
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox1.DroppedDown = !comboBox1.DroppedDown;


            //最大サイズと最小サイズを現在のサイズに設定する
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

        }

        /// <summary>
        /// 入力ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNyuuyoku_Click(object sender, EventArgs e)
        {
            //コンボボックスで選択した住所を親フォームに引き渡す変数に代入する
            strSend = comboBox1.Text;

            //フォームを閉じる
            this.Close();
        }

    }
}
