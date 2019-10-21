using System;
namespace School
{
    public class EntryCard
    {
        private int cardNr;
        bool Valid;

        public int CardNr
        {
            get
            {
                return cardNr;
            }
            set
            {
                cardNr = value;
                SetCardNr();
            }
        }

        public void SetCardNr()
        {
            Random rnd = new Random();
            cardNr = rnd.Next(1000, 9999);
            //Console.WriteLine($"Card nr is: {cardNr}");
        }



        public EntryCard(int cnr, bool isValid)
        {
            CardNr = cnr;
            Valid = isValid;
        }

        public EntryCard()
        {
        }



        //A association to the teacher class, takes the teacher as a argument.
        //Then show the date time when used.
        public void Swipe(string name)
        {
            SetCardNr();
            Console.WriteLine($"Card {cardNr} swipted at: {DateTime.Now}");
            //Console.WriteLine($"Card nr is: {cardNr}");
            Console.ReadLine();

        }
    }
}
