using System;
using System.Collections.Generic;

namespace Test_4
{
    public class Board
    {
        static void Main(string[] args)
        {
            /*--------------------------------
             *      게시판 클래스 TestCase
             --------------------------------*/
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("--------------- 게시판 클래스 ----------------");
            Console.WriteLine("---------------------------------------------");
            Board board = new Board(10);
            board.AddPost("첫 번째 게시글", "안녕하세요. 첫 번째 게시글입니다.", "작성자1");
            board.AddPost("두 번째 게시글", "안녕하세요. 두 번째 게시글입니다.", "작성자2");
            Board.Post[] posts = board.GetPosts();
            foreach (Board.Post post in posts)
            {
                Console.WriteLine($"제목: {post.Title}");
                Console.WriteLine($"작성자: {post.Author}");
                Console.WriteLine($"작성 시간: {post.PostedTime}");
                Console.WriteLine($"내용: {post.Content}");
                Console.WriteLine();
            }
            /*-----------------------------
                음악 관리 시스템 TestCase
             ------------------------------*/
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("------------- 음악 관리 시스템 ---------------");
            Console.WriteLine("---------------------------------------------");
            MusicPlayer player = new MusicPlayer(10);

            Music music1 = new Music
            {
                Name = "좋은 날",
                Artist = "아이유",
                Album = "앨범 1",
            };
            player.AddMusic(music1);

            Music music2 = new Music
            {
                Name = "Incadance",
                Artist = "Cusco",
                Album = "앨범 2",
            };
            player.AddMusic(music2);

            Music music3 = new Music
            {
                Name = "Stressed Out",
                Artist = "Twenty One Pilots",
                Album = "Blurryface",
            };
            player.AddMusic(music3);

            player.Play();              
            Console.WriteLine();
            player.Next();  
            Console.WriteLine();
            player.Pause();  
            Console.WriteLine();
            player.Next();
            Console.WriteLine();
            player.Prev();  
            Console.WriteLine();
            player.RemoveMusic(0);
            Console.WriteLine();
            player.Stop();
            Console.WriteLine();
            /*-----------------------------------
            *   호텔 예약 시스템 TestCase
            ------------------------------------*/
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("------------- 호텔 예약 시스템 ---------------");
            Console.WriteLine("---------------------------------------------");
            HotelBookingSystem hotelBookingSystem = new HotelBookingSystem();

            hotelBookingSystem.CheckIn("윤승준", "01022170710");
            Console.WriteLine();
            hotelBookingSystem.CheckIn("이영호", "01022170710");
            Console.WriteLine();
            hotelBookingSystem.CheckIn("이정재", "01011111111");
            Console.WriteLine();
            hotelBookingSystem.CheckIn("이민수", "01022170710");
            Console.WriteLine();
            hotelBookingSystem.CheckIn("박정수", "01022170710");
            Console.WriteLine();

            hotelBookingSystem.PrintBookingData("이정재");
            Console.WriteLine();

            hotelBookingSystem.CheckOut("윤승준");
            Console.WriteLine();

            hotelBookingSystem.ClearList();
            Console.WriteLine();
            /*-----------------------------------
            * 주식 투자 시뮬레이션 클래스 TestCase
            ------------------------------------*/
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("------------ 주식 투자 시뮬레이션 -------------");
            Console.WriteLine("---------------------------------------------");
            Dictionary<string, float> stocks = new Dictionary<string, float>();
            stocks.Add("삼성전자", 83000.0f);
            Console.WriteLine();
            stocks.Add("LG화학", 800000.0f);
            Console.WriteLine();
            stocks.Add("NAVER", 400000.0f);
            Console.WriteLine();

            StockInvestmentSimulator simulator = new StockInvestmentSimulator(stocks, 1000000.0f);

            simulator.BuyStock("삼성전자", 10);
            Console.WriteLine();
            simulator.BuyStock("LG화학", 2);
            Console.WriteLine();
            simulator.PrintPortfolio();
            Console.WriteLine();
            simulator.PrintBalance();
            Console.WriteLine();

            simulator.SellStock("SK하이닉스", 10);
            Console.WriteLine();
            simulator.SellStock("삼성전자", 5);
            Console.WriteLine();
            simulator.PrintPortfolio();
            Console.WriteLine();
            simulator.PrintBalance();
            Console.WriteLine();
        }
        /* ---------------------------------
        *       게시판 클래스
        ---------------------------------- */
        private Post[] posts;
        private int postCount;
        public class Post
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public DateTime PostedTime { get; set; }
            public string Author { get; set; }

            public Post(string title, string content, DateTime postedTime, string author)
            {
                Title = title;
                Content = content;
                PostedTime = postedTime;
                Author = author;
            }
        }

        public Board(int capacity)
        {
            posts = new Post[capacity];
            postCount = 0;
        }

        // 게시글 추가 메서드
        public void AddPost(string title, string content, string author)
        {
            Post post = new Post(title, content, DateTime.Now, author);
            posts[postCount] = post;
            postCount++;
        }

        // 게시글 목록 가져오기 메서드
        public Post[] GetPosts()
        {
            Post[] result = new Post[postCount];
            for (int i = 0; i < postCount; i++)
            {
                result[i] = posts[i];
            }
            return result;
        }
    }

    // 음악 재생 클래스
    public class Music
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
    }

    /* ---------------------------------
     *       음악 플레이어 
     ---------------------------------- */
    class MusicPlayer
    {
        private List<Music> playlist;
        private int currentIndex;

        public MusicPlayer()
        {
            playlist = new List<Music>();
            currentIndex = -1;
        }

        public MusicPlayer(int capacity)
        {
            playlist = new List<Music>(capacity);
            currentIndex = -1;
        }

        public void AddMusic(Music music)
        {
            playlist.Add(music);
        }

        public void RemoveMusic(int index)
        {
            if (index >= 0 && index < playlist.Count)
            {
                if (index == currentIndex)
                {
                    Stop();
                    currentIndex = -1;
                }
                Console.WriteLine("Remove Music " + playlist[index].Name);
                playlist.RemoveAt(index);
            }
        }

        public void Play()
        {
            if (playlist.Count > 0 && currentIndex < playlist.Count - 1)
            {
                currentIndex++;
                Console.WriteLine("Now playing: " + playlist[currentIndex].Name);
            }
            else
            {
                Console.WriteLine("No music in playlist.");
            }
        }

        public void Stop()
        {
            Console.WriteLine("Song stopped.");
        }

        public void Pause()
        {
            Console.WriteLine("Song paused.");
        }

        public void Next()
        {
            if (playlist.Count > 0 && currentIndex < playlist.Count - 1)
            {
                currentIndex++;
                Console.WriteLine("Now playing: " + playlist[currentIndex].Name);
            }
            else
            {
                Console.WriteLine("End of playlist.");
            }
        }

        public void Prev()
        {
            if (playlist.Count > 0 && currentIndex > 0)
            {
                currentIndex--;
                Console.WriteLine("Now playing: " + playlist[currentIndex].Name);
            }
            else
            {
                Console.WriteLine("Start of playlist.");
            }
        }
    }

    /* ---------------------------------
     *       호텔 예약 시스템
     ---------------------------------- */
    public class Guest
    {
        public string GuestName { get; set; }
        public string GuestPhoneNum { get; set; }
        
        public void PrintGuestData()
        {
            Console.WriteLine("손님 이름 : " + GuestName);
            Console.WriteLine("손님 전화번호 : " + GuestPhoneNum);

        }
    }

    public class HotelBooking
    {
        public HotelBooking() { Guest = new Guest(); BookingId = ++bookingCount; }
        public Guest Guest { get; set; }  
        public int BookingId { get; set; }
        public string RoomNum { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        static private int bookingCount = 0;
    }

    public class HotelBookingSystem
    {
        private List<string> availableRooms;

        public List<HotelBooking> HotelBookingList { get; set; } = new List<HotelBooking>();
        
        public HotelBookingSystem()
        {
            availableRooms = new List<string>{ "101", "102", "103", "201", "202", "203" };
        }

        public int CheckAvailableRooms()
        {
            return availableRooms.Count;
        }

        public HotelBooking FindBookingData(string guestName)
        {
            HotelBooking findData = null;
            foreach(HotelBooking hotel in HotelBookingList)
            {
                if (hotel.Guest.GuestName == guestName)
                {
                    findData = hotel;
                    break;
                }
            }
            return findData;
        }
        
        public void PrintBookingData(HotelBooking hotelBooking)
        {
            hotelBooking.Guest.PrintGuestData();
            Console.WriteLine("방 번호 : " + hotelBooking.RoomNum);
            Console.WriteLine("체크인 날자 : " + hotelBooking.CheckInDate.ToString());
            Console.WriteLine("체크아웃 날자 : " + hotelBooking.CheckOutDate.ToString());
            Console.WriteLine("예약 번호 : " + hotelBooking.BookingId);
        }
        public void PrintBookingData(string guestName)
        {
            HotelBooking findData = FindBookingData(guestName);
            if(findData == null)
            {
                Console.WriteLine("찾으시는 이름의 고객님이 방을 예약하신 적 없습니다.");
                return;
            }
            PrintBookingData(findData);
        }

        public void CheckIn(string name, string phoneNumber)
        {
            if(CheckAvailableRooms() == 0)
            {
                Console.WriteLine("예약 가능한 객실 수가 없습니다.");
                return;
            }
            HotelBooking newHotelBook = new HotelBooking();
            newHotelBook.RoomNum = availableRooms[0];
            availableRooms.RemoveAt(0);

            Console.WriteLine(name + " 고객님이 " + newHotelBook.RoomNum + "호 객실을 예약했습니다. ");
            newHotelBook.Guest.GuestName = name;
            newHotelBook.Guest.GuestPhoneNum = phoneNumber; 
            newHotelBook.CheckInDate = DateTime.Now;
            newHotelBook.CheckOutDate = newHotelBook.CheckInDate.AddDays(1);

            Console.WriteLine(newHotelBook.CheckInDate.ToString() + "에 체크인하셨으며, " +
                newHotelBook.CheckOutDate.ToString() + "까지 체크아웃해 주십시오. ");

            HotelBookingList.Add(newHotelBook);
        }

        public void CheckOut(HotelBooking bookData)
        {
            Console.WriteLine("현재 시간 : " + DateTime.Now.ToString());
            Console.WriteLine(bookData.Guest.GuestName + " 고객님이 체크아웃하셨습니다.");
            availableRooms.Add(bookData.RoomNum);
            HotelBookingList.Remove(bookData);
        }

        public void CheckOut(string name)
        {
            HotelBooking bookData = FindBookingData(name);
            if (bookData == null)
                return;
            CheckOut(bookData);
        }

        public void ClearList()
        {
            while (HotelBookingList.Count > 0)
                CheckOut(HotelBookingList[0]);
        }

    }

    /* ---------------------------------
     *  주식 투자 시뮬레이션 
     ---------------------------------- */
    public class StockInvestmentSimulator
    {
        private Dictionary<string, float> stocks; // 주식 종목과 가격 정보를 담고 있는 딕셔너리
        private Dictionary<string, int> portfolio; // 보유한 주식 종목과 수량 정보를 담고 있는 딕셔너리
        private float balance; // 현재 계좌 잔고

        public StockInvestmentSimulator(Dictionary<string, float> stocks, float initialBalance)
        {
            this.stocks = stocks;
            portfolio = new Dictionary<string, int>();
            balance = initialBalance;
        }

        public void BuyStock(string stockName, int quantity)
        {
            float price = stocks[stockName];
            float cost = price * quantity;

            if (balance < cost)
            {
                Console.WriteLine("주식을 구매하기에 충분한 잔고가 없습니다.");
                return;
            }

            balance -= cost;

            if (portfolio.ContainsKey(stockName))
            {
                portfolio[stockName] += quantity;
            }
            else
            {
                portfolio.Add(stockName, quantity);
            }

            Console.WriteLine("{1} 주식 {0}주를 {2}원에 구매하였습니다.", quantity, stockName, price);
        }

        public void SellStock(string stockName, int quantity)
        {
            if (!portfolio.ContainsKey(stockName))
            {
                Console.WriteLine("보유하고 있지 않은 {1} 주식 {0}주를 판매할 수 없습니다.", quantity, stockName);
                return;
            }

            int currentQuantity = portfolio[stockName];

            if (quantity > currentQuantity)
            {
                Console.WriteLine("현재 {1} 주식을 {0}개 보유하고 있어 {2}개만큼 판매할 수 없습니다.", currentQuantity, stockName, quantity);
                return;
            }

            float price = stocks[stockName];
            float income = price * quantity;

            balance += income;
            portfolio[stockName] -= quantity;

            Console.WriteLine("{0} 주식 {1}주를 주당 {2}원에 판매하였습니다.", stockName, quantity, price);
            Console.WriteLine("총 판매액: " + income + "원");
        }

        public float GetPortfolioValue()
        {
            float value = 0.0f;

            foreach (var stock in portfolio)
            {
                string stockName = stock.Key;
                int quantity = stock.Value;
                float price = stocks[stockName];

                value += price * quantity;
            }

            return value;
        }

        public float GetStockPrice(string stockName)
        {
            return stocks[stockName];
        }

        public void PrintPortfolio()
        {
            Console.WriteLine("보유중인 주식 포트폴리오:");

            foreach (var stock in portfolio)
            {
                string stockName = stock.Key;
                int quantity = stock.Value;

                Console.WriteLine("{0}: {1}주", stockName, quantity);
            }
        }

        public void PrintBalance()
        {
            Console.WriteLine("현재 계좌 잔고: " + balance + "원");
        }
    }
}

