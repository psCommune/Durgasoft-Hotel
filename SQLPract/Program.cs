// See https://aka.ms/new-console-template for more information
using Bogus;
using SQLPract.Models;
using SQLPract;
using static System.Console;


Random rnd = new Random();
CafeContext context = new CafeContext();

/*var cafeType = context.cafeTypes.ToArray();
var cafe = context.Cafe.ToArray();
var user = context.Users.ToArray();
Faker<Review> faker = new Faker<Review>("ru");
var rew = faker
    .RuleFor(rw => rw.Cafe, r => r.Random.ArrayElement(cafe))
    .RuleFor(rw => rw.User, r => r.Random.ArrayElement(user))
    .RuleFor(rw => rw.Time, r => r.Date.Between(new DateTime(2018, 01, 01), new DateTime(2022, 12, 01)))
    .RuleFor(rw => rw.Stars,r => r.Random.Number(0, 5))
    .GenerateLazy(350).ToList();*/



/*Faker<Cafe> faker = new Faker<Cafe>("ru");
var users = faker
    .RuleFor(u => u.CafeName, r => r.Company.CompanyName())
    .RuleFor(c=>c.Address, r => r.Address.StreetAddress())
    .RuleFor(c => c.City, r => r.Address.City())
    .RuleFor(c => c.CafeType, r => r.Random.ArrayElement(cafeType))
    .GenerateLazy(350)
    .ToList();*/

/*foreach(var review in rew )
{
   context.Add(review);
}*/
//context.SaveChanges();

//Work.AllCafe();
//Work.SearchUser("Никит");
//Work.ReviewCafe("Пол");
Work.happyAndAngry();
//Work.MostPopular();
//Work.averageGrade();
//Work.topthree();
Work.addReview(1,1, 5);
