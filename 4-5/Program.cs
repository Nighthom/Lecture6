using System;
using System.Collections.Generic;

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
}

