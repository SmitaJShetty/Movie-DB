using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.Entities
{
    public class Movie
    {
        public int? MovieId{get;set;}
        public string Title {get;set; }
        public List<string> Cast{get;set;}
        public int ReleaseDate { get; set; }
        public string Classification { get; set; }
        public int Rating { get; set; }
        public string Genre { get; set; }

        public static bool TryParse(string RawValue, out Movie Result)
        {
            Result = null;

            var parts = RawValue.Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length > 0)
            {
                string[] valParts;
                string key, value;

                foreach (string part in parts)
                {
                    valParts = part.Split(new char[] { '=' }, StringSplitOptions.None);

                    if (valParts.Length == 2)
                    {
                        key = valParts[0].Trim().ToLower();
                        value = valParts[1].Trim().ToLower();

                        if (!string.IsNullOrEmpty(key))
                        {
                            switch (key)
                            {
                                case "movieid":
                                    int Id = 0;
                                    if (Int32.TryParse(value, out Id))
                                    {
                                        Result.MovieId = Id;
                                    }
                                    else
                                    {
                                        Result.MovieId = null;
                                    }
                                    break;

                                case "title":
                                    Result.Title = value;
                                    break;
                                case "releasedate":
                                    int relDate = 0;
                                    if (int.TryParse(value, out relDate))
                                    {
                                        Result.ReleaseDate = relDate;
                                    }
                                    break;
                                case "rating":
                                    int rating = -1;
                                    if (int.TryParse(value, out rating))
                                    {
                                        Result.Rating = rating;
                                    }
                                    break;
                                case "genre":
                                    Result.Genre = value;
                                    break;
                                case "classification":
                                    Result.Classification = value;
                                    break;

                            }
                        }
                    }
                }
            }
            else 
            { 
                return false; 
            }

            if ((Result.MovieId == null) && (String.IsNullOrEmpty(Result.Title)))
            {
                return false;
            }

            return true;
        }
    }
}
