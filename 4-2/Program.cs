using System;



namespace _4_2
{
    public class Order
    {
        // Properties
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string OrderDate { get; set; }
        public string OrderedProduct { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Address { get; set; }

        // 인스턴스 변수
        private string PhoneNumber;
        // 클래스 변수
        static private int _id = 0;

        // 생성자
        public Order() { }
        // 생성자 오버로딩
        public Order(string customerName, string orderDate, string orderedProduct, int quantity, double price, string address, string phoneNumber)
        {
            OrderNumber = ++_id;
            CustomerName = customerName;
            OrderDate = orderDate;
            OrderedProduct = orderedProduct;
            Quantity = quantity;
            Price = price;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        // Methods
        public void CreateOrder()
        {
            Console.WriteLine($"주문자 이름: {CustomerName}");
            Console.WriteLine($"주문 날짜: {OrderDate}");
            Console.WriteLine($"상품: {OrderedProduct}");
            Console.WriteLine($"가격: {Price:C}");
            Console.WriteLine($"수량: {Quantity}");
            Console.WriteLine($"주소: {Address}");
            Console.WriteLine($"전화번호: {PhoneNumber}");
            Console.WriteLine();
            Console.WriteLine("새로운 주문이 생성되었습니다.");
        }

        public void CancelOrder()
        {
            Console.WriteLine("주문이 취소되었습니다.");
        }

        public void Pay()
        {
            Console.WriteLine("주문이 결제되었습니다. \\" + Price);
        }

        public void Delivery()
        {
            Console.WriteLine($"{CustomerName} 님의 주문이 {Address}로 배송되었습니다. ");
            Console.WriteLine($"상품명 : {OrderedProduct}");
        }

        // 오버로딩
        public void Delivery(string address)
        {
            Address = address;
            Delivery();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order("윤승준", "2021-01-01", "침대", 10, 100000, "대전시", "01022170710");

            order.CreateOrder();
            order.Pay();

            order.Delivery();
            Console.WriteLine();
            order.Delivery("대전시 동구 홍도동");
        }
    }
}
