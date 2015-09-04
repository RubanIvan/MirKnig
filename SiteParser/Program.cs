using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace SiteParser
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlWeb webGet = new HtmlWeb()
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.GetEncoding(1251)
            };

            //HtmlDocument document = webGet.Load("http://mirknig.com/page/1000/");

            //название книги
            HtmlNode Header;
            string title;

            //Жанр книги
            HtmlNodeCollection Genge;
            int genreID;

            //картинка
            HtmlNode ImgNode;
            string ImgSrc;


            //Аттрибуты книги
            HtmlNodeCollection BookAttrs;
            string bookattr;
            string bookattrval;


            HtmlNode DescNode;

            string author = "";
            string publisher = "";
            string year = "";
            int? pages = null;
            int languageId = 1;
            string description = "";

            //if (File.Exists("imgsrc.txt")) File.Delete("imgsrc.txt");
            StreamWriter Stream = File.AppendText("imgsrc.txt");

            MirKnigEntities MirKnigEntities = new MirKnigEntities();

            for (int i = 200; i < 300; i++)
            {

                HtmlDocument document = webGet.Load("http://mirknig.com/page/" + i.ToString());


                //выбираем блоки с книгами
                HtmlNodeCollection NodeCollection = document.DocumentNode.SelectNodes("//div[@class='infoboxStory']");

                foreach (HtmlNode Node in NodeCollection)
                {

                    author = "";
                    publisher = "";
                    year = "";
                    pages = null;
                    languageId = 1;
                    description = "";

                    //Console.WriteLine(Node.InnerText);
                    Console.WriteLine("--------------------------"+i+"---------------------------------");

                    

                    //получаем название книги
                    Header = Node.SelectSingleNode(".//div[@class='cellMiddleTitle']/a");
                    if (Header == null) continue;
                    title = Header.InnerText;
                    

                    //получаем жанр
                    Genge = Node.SelectNodes(".//div[@class='cellRightTitle']/strong/a");
                    if (Genge[0].InnerText != "КНИГИ") continue;
                    
                    genreID = GetGenreByName(Genge[1].InnerText);
                    //Console.WriteLine(genreID);


                    

                    //адрес картинки
                    ImgNode = Node.SelectSingleNode(".//div[@class='newsbody']/a/img");
                    if (ImgNode == null) ImgNode = Node.SelectSingleNode(".//div[@class='newsbody']/img");
                    ImgSrc = ImgNode.Attributes.First(x => x.Name == "src").Value;
                    Stream.WriteLine(@"http://mirknig.com" + ImgSrc);
                    Stream.Flush();
                    ImgSrc = Path.GetFileName(ImgSrc);

                    Console.WriteLine(title);
                    Console.WriteLine(Genge[1].InnerText);
                    Console.WriteLine(ImgSrc);


                    //берем заголовки книги
                    BookAttrs = Node.SelectNodes(".//div[@class='newsbody']/b");
                    if (BookAttrs == null) continue;

                    foreach (HtmlNode Attr in BookAttrs)
                    {
                        bookattr = Attr.InnerText.Replace(':', ' ').Trim().ToLower();
                        bookattrval = Attr.NextSibling.InnerText.Trim();

                        if (bookattrval.Length > 0 && bookattrval[0] == ':') bookattrval = bookattrval.Substring(2);

                        if (bookattr == "автор") author = bookattrval;
                        if (bookattr == "издательство" || bookattr == "издатель") publisher = bookattrval;
                        if (bookattr == "год") year = bookattrval;
                        if (bookattr == "страниц")
                        {
                            int page;
                            if (int.TryParse(bookattrval, out page)) pages = page;
                        }
                        if (bookattr == "язык" && bookattrval == "English") languageId = 2;


                    }


                    //анатация
                    DescNode = Node.SelectSingleNode(".//div[@class='newsbody']");

                    for (int j = DescNode.ChildNodes.Count - 1; j >= 0; j--)
                    {
                        if (DescNode.ChildNodes[j].InnerText.Length > 20)
                        {
                            description = DescNode.ChildNodes[j].InnerText.Trim();
                            break;
                        }
                    }

                    MirKnigEntities.Book.Add(new Book()
                    {
                        Description = description,
                        Author = author,
                        Title = title,
                        Year = year,
                        Publisher = publisher,
                        GenreID = genreID,
                        LanguageID = languageId,
                        Pages = pages,
                        CoverFileName = ImgSrc
                    });
                    MirKnigEntities.SaveChanges();


                }


            }
            Stream.Close();
            Console.ReadLine();
        }

        static int GetGenreByName(string GenreName)
        {
            GenreName = GenreName.ToUpper().Replace(':', ' ').Trim();
            switch (GenreName)
            {
                case "АППАРАТУРА": return 1;
                case "БИЗНЕС": return 2;
                case "БЕЛЛЕТРИСТИКА": return 3;
                case "ВОЕННАЯ ИСТОРИЯ": return 4;
                case "ГУМАНИТАРНЫЕ НАУКИ": return 5;
                case "ДЛЯ ДЕТЕЙ": return 6;
                case "ДИЗАЙН": return 7;
                case "ДИЗАЙН И ГРАФИКА": return 8;
                case "ДОМ И СЕМЬЯ": return 9;
                case "ЕСТЕСТВЕННЫЕ НАУКИ": return 10;
                case "ЖИВОПИСЬ И РИСОВАНИЕ": return 11;
                case "ЗДОРОВЬЕ": return 12;
                case "ИСТОРИЯ": return 13;
                case "КУЛИНАРИЯ": return 14;
                case "КУЛЬТУРА и ИСКУССТВО": return 15;
                case "НАУКА И УЧЕБА": return 16;
                case "НАУЧНО-ПОПУЛЯРНОЕ": return 17;
                case "ОС И БД": return 18;
                case "ПРОГРАММИНГ": return 19;
                case "ПРОФЕССИИ И РЕМЕСЛА": return 20;
                case "ПСИХОЛОГИЯ": return 21;
                case "РЕЛИГИЯ": return 22;
                case "СТИХИ И ПОЭЗИЯ": return 23;
                case "СЕТЕВЫЕ ТЕХНОЛОГИИ": return 24;
                case "ТЕХНИКА": return 25;
                case "ХОББИ И РЕМЕСЛА": return 26;
                case "ФОТО-ВИДЕО": return 27;
                case "ХОББИ И РАЗВЛЕЧЕНИЯ": return 28;
                case "WEB-СОЗИДАНИЕ": return 29;
                case "ЧЕЛОВЕК": return 30;
                case "ФАНТАСТИКА": return 31;
                case "ЭЗОТЕРИКА": return 32;
                case "РАЗНОЕ": return 33;

            }
            return 33;
        }

    }
}
