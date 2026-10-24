namespace G26W07WFCardDealer {
    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
        }

        private void OnDeal(object sender, EventArgs e) {
            string[] suits = ["spades", "hearts", "diamonds", "clubs"];
            string[] values = ["ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king"];
            int[] card_value = new int[52];
            int value;
            PictureBox[] cardBoxes = [Card1, Card2, Card3, Card4, Card5];
            Random random = new Random();

            // 5장 뽑기 반복문 (0부터 4까지)
            for (int i = 0; i < 5; ++i) {
                while (true) {
                    value = random.Next(52); // 0 ~ 51 중 랜덤 선택
                    if (card_value[value] == 0) {
                        break;
                    }
                }
                card_value[value] = 1; // 중복 방지 마킹

                // 올바른 카드 이름 매핑 공식
                int suitIndex = value / 13;   // 0 ~ 3 (무늬)
                int valueIndex = value % 13;  // 0 ~ 12 (숫자/알파벳)

                // J, Q, K인 경우와 일반 숫자인 경우에 따라 리소스 이름 다르게 지정
                string name = (valueIndex is 11 or 12 or 10)
                    ? $"{values[valueIndex]}_of_{suits[suitIndex]}2"
                    : $"{values[valueIndex]}_of_{suits[suitIndex]}";

                cardBoxes[i].Image = Properties.Resources.ResourceManager.GetObject(name) as Image;
            }
        }
    }
}