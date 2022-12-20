using Microsoft.EntityFrameworkCore;
using SQLPract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace SQLPract
{

    public static class Work
    {


        public static void AllCafe()
        {
            CafeContext context = new CafeContext();
            var caf = context.Cafe.Include(c => c.CafeType);
            foreach (var cafe in caf)
            {
                WriteLine($"{cafe.CafeName} {cafe.Address} {cafe.CafeType.Title}");
            }
        }

        public static void AllCafeOneType()
        {
            CafeContext context = new CafeContext();
            var caf = context.Cafe.Include(c => c.CafeType).Where(c => c.CafeType.CafeTypeId == 3);
            foreach (Cafe cafe in caf)
            {
                WriteLine($"{cafe.CafeName} {cafe.Address} {cafe.CafeType.Title}");
            }
        }

        public static void SearchUser(string search)
        {
            CafeContext context = new CafeContext();
            var caf = context.Users.Where(c => c.UserName.Contains(search));
            foreach (var user in caf)
            {
                WriteLine(user.UserName + " " + user.UserId);
            }
        }
        public static void ReviewCafe(string search)
        {
            CafeContext context = new CafeContext();
            var caf = context.reviews
                .Include(c => c.User)
                .Include(c => c.Cafe)
                .Where(c => c.Cafe.CafeName.Contains(search));

            foreach (var user in caf)
            {
                string stars = "";
                for (int i = 0; i < user.Stars; i++)
                {
                    stars += '*';
                }
                stars += "/*****";
                WriteLine(user.User.UserName + " " + user.Cafe.CafeName + " " + stars);
            }
        }
        public static void happyAndAngry()
        {
            CafeContext context = new CafeContext();
            var groups =
                context.reviews.Include(r => r.User).GroupBy(r => r.User).ToList();

            var userMax = groups.First().Key;
            var userMin = groups.First().Key;
            var maxCount = groups.First().Count(r => r.Stars == 5);
            var minCount = groups.First().Count(r => r.Stars == 0);

            foreach (var group in groups)
            {
                var count = group.Count(r => r.Stars == 5);

                if (count > maxCount)
                {
                    maxCount = count;
                    userMax = group.Key;
                }
            }

            Console.WriteLine(userMax.UserName + " " + maxCount);
            foreach (var group in groups)
            {
                var count = group.Where(r => r.Stars == 0).Count();

                if (count > minCount)
                {
                    minCount = count;
                    userMax = group.Key;
                }
            }
            Console.WriteLine(userMin.UserName + " " + minCount);
        }
        public static void averageGrade()
        {
            CafeContext context = new CafeContext();
            var groups =
                 context.reviews
                 .Include(r => r.User)
                 .Include(r => r.Cafe)
                 .GroupBy(r => r.Cafe)
                 .ToList();
            foreach(var cafe in groups)
            {
                double up = 0;
                double down = 0;
                foreach(var rew in cafe)
                {
                    up += rew.Stars;
                    down++;
                }
                WriteLine(cafe.Key.CafeName+" -- "+up/down);
                
            }
        }


        public static void MostPopular()
        {
            CafeContext context = new CafeContext();
            var groups =
                context.reviews.Include(r => r.Cafe)
                .GroupBy(r => r.Cafe)
                .ToList();
            var count = groups
                .OrderBy(g => g.Count())
                .Select(g => new { cafe = g.Key, count = g.Count() })
                .Take(10);
            foreach(var rew in count)
            {
                WriteLine(rew.cafe.CafeName);
            }
        }
        public static void topthree()
        {
            CafeContext Context = new CafeContext();
            //int i = 1;
            var group = Context.reviews.Include(r => r.Cafe)
                .GroupBy(r => r.Cafe).ToList();
            var TopThre = group
                .OrderByDescending(g => g.Average(r => r.Stars))
                .Take(3)
                .ToList();

            foreach (var gr in TopThre)
            {
                WriteLine(gr.First().Cafe.CafeName + " == " + gr.Average(r => r.Stars));
            }
        }

        public static void addReview(int iUser, int iCafe, int star )
        {
            CafeContext Context = new CafeContext();
            var index = Context.Users.Find(iUser);
            var indexx = Context.Cafe.Find(iCafe);

            Review rv = new Review()
            {
                User = index,
                Cafe = indexx,
                Stars = star,
                Time = DateTime.Now,
            };
            Context.reviews.Add(rv);
            Context.SaveChanges();
        }

        
    }
}
