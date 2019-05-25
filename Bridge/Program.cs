using System;

namespace Bridge
{
    class Program
    {
        /*Bir nesnenin içinde soyutlanabilir kısımlar varsa, bu kısımların soyutlama teknikleriyle soyutlanması üzerine
         bir desendir.*/
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager();
            //productManager.MessageSenderBase = new MailSender();
            productManager.MessageSenderBase = new MessageSender();
            productManager.UpdateProduct();
            Console.ReadLine();
        }
    }
    #region Base
    abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Saved");
        }

        public abstract void Send(Body body);
    }

    class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
    #endregion


    #region İmplementasyonlar

    class MailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0}, MailSender ile gönderildi", body.Title);
        }
    }

    class MessageSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0}, MessageSender ile gönderildi", body.Title);
        }
    }

    #endregion

    #region Kullanılan Yer

    class ProductManager
    { //Burda bir ürün güncellendiğinde bridge aracılığıyla mesaj gönderilsin...

        public MessageSenderBase MessageSenderBase { get; set; }
        public void UpdateProduct()
        {
            MessageSenderBase.Send(new Body{Title="Bilgilendirme mesajıdır"});
            Console.WriteLine("Ürün güncellendi");
        }
    }

    #endregion


}
