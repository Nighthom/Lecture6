using System;

namespace _4_4
{
    public class FoodOrderSystem
    {
        // Properties
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string OrderDate { get; set; }
        public string MenuName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        static private int _id = 0;

        // Default Constructor
        public FoodOrderSystem()
        {
            OrderNumber = ++_id;
            CustomerName = "";
            OrderDate = "";
            MenuName = "";
            Quantity = 0;
            Price = 0;
            Address = "";
            PhoneNumber = "";
        }

        // Constructor
        public FoodOrderSystem(string customerName, string orderDate, string menuName, int quantity, int price, string address, string phoneNumber)
        {
            OrderNumber = ++_id;
            CustomerName = customerName;
            OrderDate = orderDate;
            MenuName = menuName;
            Quantity = quantity;
            Price = price;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        // Methods
        public void SelectMenu(string menuName)
        {
            MenuName = menuName;
            Console.WriteLine($"메뉴 \"{menuName}\"이 선택되었습니다.");
        }

        public void InputQuantity(int quantity)
        {
            Quantity = quantity;
            Console.WriteLine($"수량 \"{quantity}\"이 입력되었습니다.");
        }

        public void CalculatePrice(int price)
        {
            Price = Quantity * price;
            Console.WriteLine($"총 가격은 {Price}원 입니다.");
        }

        public void CreateOrder()
        {
            Console.WriteLine("주문이 생성되었습니다.");
            Console.WriteLine($"주문번호: {OrderNumber}");
            Console.WriteLine($"주문자명: {CustomerName}");
            Console.WriteLine($"주문일자: {OrderDate}");
            Console.WriteLine($"주문메뉴: {MenuName}");
            Console.WriteLine($"수량: {Quantity}");
            Console.WriteLine($"가격: {Price}원");
            Console.WriteLine($"주소: {Address}");
            Console.WriteLine($"전화번호: {PhoneNumber}");
        }

        public void Payment()
        {
            Console.WriteLine("결제가 완료되었습니다.");
        }

        public void Delivery()
        {
            Console.WriteLine("배송이 시작되었습니다.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            FoodOrderSystem order = new FoodOrderSystem("윤승준", "2000-01-01", "치킨" ,10, 10000, "대전시", "01000000000");
            order.CreateOrder();
            order.Payment();
            order.Delivery();
        }
    }
}
