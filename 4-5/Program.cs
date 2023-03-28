using System;

namespace Test_4
{
    public class Board
    {
        static void Main(string[] args)
        {
            // 게시판 클래스 사용 예시 
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

            // 음악 관리 시스템 예제
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
            player.Next();  
            player.Pause();  
            player.Next();
            player.Prev();  
            player.RemoveMusic(0);  
        }

        private Post[] posts;
        private int postCount;

        // 게시글 클래스
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

    public class MusicPlayer
    {
        private Music[] playlist;
        private int currentTrackIndex;

        public MusicPlayer(int capacity)
        {
            playlist = new Music[capacity];
            currentTrackIndex = -1;
        }

        public void AddMusic(Music music)
        {
            for (int i = 0; i < playlist.Length; i++)
            {
                if (playlist[i] == null)
                {
                    playlist[i] = music;
                    Console.WriteLine("음악 " + music.Name + " 을(를) 플레이리스트에 추가했습니다.");
                    return;
                }
            }
            Console.WriteLine("플레이리스트가 가득 찼습니다.");
        }

        public void RemoveMusic(int index)
        {
            if (index < 0 || index >= playlist.Length)
            {
                Console.WriteLine("잘못된 인덱스입니다.");
                return;
            }

            if (playlist[index] == null)
            {
                Console.WriteLine("해당 인덱스에는 음악이 아직 잡혀있지 않습니다.");
                return;
            }

            Console.WriteLine("음악 " + playlist[index].Name + "을(를) 삭제했습니다.");
            playlist[index] = null;
        }

        public void Play()
        {
            if (playlist.Length == 0)
            {
                Console.WriteLine("플레이리스트에 음악이 없습니다.");
                return;
            }
            currentTrackIndex = 0;
            Console.WriteLine("음악 재생중.. " + playlist[currentTrackIndex].Name);
        }

        public void Play(int index)
        {
            if (playlist.Length == 0)
            {
                Console.WriteLine("플레이리스트에 음악이 없습니다.");
                return;
            }
            currentTrackIndex = index;
            Console.WriteLine("음악 재생중.. " + playlist[currentTrackIndex].Name);
        }

        public void Pause()
        {
            Console.WriteLine("음악을 일시 중지합니다.");
        }

        public void Stop()
        {
            Console.WriteLine("음악을 정지합니다.");
            currentTrackIndex = -1;
        }

        public void Next()
        {
            if (currentTrackIndex == -1)
            {
                Console.WriteLine("음악이 재생되고 있지 않습니다. ");
                return;
            }

            if (currentTrackIndex >= playlist.Length - 1)
            {
                Console.WriteLine("마지막 음악입니다.");
                return;
            }
            Play(currentTrackIndex + 1);
        }

        public void Prev()
        {
            if (currentTrackIndex == -1)
            {
                Console.WriteLine("음악이 재생되고 있지 않습니다.");
                return;
            }

            if (--currentTrackIndex <= 0)
            {
                Console.WriteLine("첫 음악입니다.");
                return;
            }

            Play(currentTrackIndex - 1);
        }
    }
}
