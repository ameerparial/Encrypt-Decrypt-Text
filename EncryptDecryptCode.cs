using System;
using System.Windows.Forms;

namespace CSharp{

    public class EncryptDecrypt:Form{
        private TextBox msgTB;
        private Button encryptBTN;
        private Button decryptBTN;
        private Label showMsgLB;
        private Label showTextLB;

        public EncryptDecrypt(){
            setComponents();            
        }

        public void EncryptText(object source, EventArgs e){
            showTextLB.Text = "";
            showMsgLB.Text = "Encrypted Text:";
            String text = msgTB.Text.Trim();
            if(text==""){
                MessageBox.Show("Please Enter Some Text!!");
                return;
            }
            String[] originalWords = text.Split(' ');
            foreach(String word in originalWords)
                showTextLB.Text += EncryptWord(word)+" ";
            
        }

        public void DecryptText(object source, EventArgs e){
            MessageBox.Show("Error!!");
        }

        private String EncryptWord(String word){
            int half = word.Length/2;
            if(word.Length%2!=0)
                half += 1;

            char[] vowels = {'a', 'e', 'i', 'o', 'u'};
            bool toggle = false;
            String encryptedWord = "";
            for(int i=0;i<word.Length;i++){
                char letter = word[i];
                if(isVowel(letter)){
                    //part one
                    if(i<half){
                        //replace with previous vowel.
                        int index = indexOf(letter) - 1;
                        if(index == -1){
                            index = vowels.Length - 1;
                        }
                        encryptedWord += vowels[index];
                    }

                    //part two
                    else{
                        //replace with 2nd vowel from current.
                        int index = indexOf(letter);
                        index = (index+2)%vowels.Length;
                        encryptedWord += vowels[index];
                    }
                }
                else{
                    //to be replace with next constant.
                    if(toggle){
                        letter++;
                        if(isVowel(letter))
                            letter++;
                        
                        if(letter > 'z')
                            letter = 'a';
                        encryptedWord += letter;                        
                    }
                    else
                        encryptedWord += word[i];
                    toggle = !toggle;
                }                
            }

            return encryptedWord;
        }

        private int indexOf(char letter){
            char[] vowels = {'a', 'e', 'i', 'o', 'u'};
            for(int i=0;i<vowels.Length;i++)
                if(letter == vowels[i])
                    return i;
            
            return -1;
        }
        private bool isVowel(char letter){
            return letter=='a'|| letter=='e' || letter =='i' || letter == 'o' || letter =='u';
        }

        private char FindNextConsont(char letter){  
            return letter;
        }

        public void setComponents(){
            //setting Form
            this.Width = 500;
            this.Text = "Excrypt-Decrypt-Program";
            this.StartPosition = FormStartPosition.CenterScreen;

            //Initialize the controllers
            msgTB = new TextBox();
            msgTB.Width = this.Width - 50;
            msgTB.Left = 20;
            msgTB.Top = 10;

            encryptBTN = new Button();
            // encryptBTN.Width =  this.Width - 50;
            encryptBTN.Left = 20;
            encryptBTN.Top = msgTB.Top + 40;
            encryptBTN.Text = "Encrypt";
            encryptBTN.Click += new System.EventHandler(this.EncryptText);

            decryptBTN = new Button();
            // decryptBTN.Width = 50;
            decryptBTN.Left = msgTB.Right - decryptBTN.Width;
            decryptBTN.Top = msgTB.Top + 40;
            decryptBTN.Text = "Decrypt";
            decryptBTN.Click += new System.EventHandler(this.DecryptText);

            showMsgLB = new Label();
            showMsgLB.Left = encryptBTN.Left;
            showMsgLB.Top = encryptBTN.Top + 40;

            showTextLB = new Label();
            showTextLB.Width = msgTB.Width;
            showTextLB.Left = showMsgLB.Left;
            showTextLB.Top = showMsgLB.Top + 20;
            
            this.Controls.Add(msgTB);
            this.Controls.Add(encryptBTN);
            this.Controls.Add(decryptBTN);  
            this.Controls.Add(showMsgLB);
            this.Controls.Add(showTextLB);                

        }

        
        public static void Main(String[] ars){
            Application.Run(new EncryptDecrypt());

        }
    }



}

