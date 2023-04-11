using System;
using System.Net;
public class Address
{
    public string addr = "";
}
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

        // 인스턴스 변수
        private string PhoneNumber;
        // 클래스 변수
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
            Console.WriteLine($"{CustomerName} 님의 음식이 {Address}로 배송되었습니다. ");
            Console.WriteLine($"상품명 : {MenuName}");
        }
        // 해당 메서드는 값을 복사해서 내부의 WriteLine 함수에 전달한다.
        // 값 복사에 해당하기 때문에 사용중인 값을 다른 값으로 변경해도 
        // 다른 값에는 영향을 미치지 않는다.
        public void Delivery(string address)
        {
            Address = address;
            // null로 밀어도 원본은 영향 X!
            address = null;
            Delivery();
        }

        // 참조 복사
        public void GetCurrAddr(Address addr)
        {
            addr.addr = Address;
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

            Console.WriteLine();
            order.Delivery("대전 동구 홍도동");

            // 참조 복사 실험 코드
            Address addr = new Address();
            order.GetCurrAddr(addr);
            Console.WriteLine("현재 주소 : " + addr.addr);
        }
    }
}
