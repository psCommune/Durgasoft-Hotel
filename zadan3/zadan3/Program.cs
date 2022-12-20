using Bogus;
using Microsoft.EntityFrameworkCore;
using zadan3.Models;

CafeContext context = new CafeContext();

var cafeTypes = context.CafeTypes.ToArray();
var allCafe = context.Cafe.ToArray();
var allUser = context.Users.ToArray();

//Faker<User> fakerUser = new Faker<User>("ru");
//var fakeUser = fakerUser.RuleFor(c => c.Name, r => r.Person.FullName).GenerateLazy(1000).ToList();

//Faker<Cafe> fakerCafe = new Faker<Cafe>("ru");
//var fakeCafe = fakerCafe
//    .RuleFor(c => c.Name, r => r.Commerce.ProductName())
//    .RuleFor(c => c.City, r => r.Address.City())
//    .RuleFor(c => c.Address, r => r.Address.FullAddress())
//    .RuleFor(c => c.CafeType, r => r.Random.ArrayElement(cafeTypes))
//    .GenerateLazy(100).ToList();

//Faker<Review> fakerReview = new Faker<Review>("ru");
//var fakeReview = fakerReview
//    .RuleFor(rw => rw.User, r => r.Random.ArrayElement(allUser))
//    .RuleFor(rw => rw.Cafe, r => r.Random.ArrayElement(allCafe))
//    .RuleFor(rw => rw.Time, r => r.Date.Between(new DateTime(2021, 11, 13), new DateTime(2022, 12, 13)))
//    .RuleFor(rw => rw.Stars, r => r.Random.Char('1', '5'))
//    .GenerateLazy(100).ToList();

//Заполнение бд
//foreach (Cafe cafe in fakeCafe)
//{
//    context.Cafe.Add(fakerCafe);
//}

//foreach(User user in fakeUser)
//{
//    context.Users.Add(fakerUser);
//}

//foreach (Review rew in fakeReview)
//{
//    context.Review.Add(fakerReview);
//}
//context.SaveChanges();

//Задание 1
//foreach (Cafe cafe in fakeCafe)
//{
//    Console.WriteLine($"Название:{cafe.Name} | Адрес:{cafe.Address} | Тип кафе:{cafe.CafeType.CafeTypeTitle}");
//}

//Задание 2
//foreach (Cafe c in context.Cafe.Include(c => c.CafeType).Where(c => c.CafeType.CafeTypeTitle == "Bar"))
//{
//    Console.WriteLine($"Название:{c.Name} | Адрес:{c.Address} | Тип кафе:{c.CafeType.CafeTypeTitle}");
//}

//Задание 3
//Console.WriteLine("Введите ФИО для поиска");
//string searchUser = Console.ReadLine();
//foreach(User user in context.Users.Where(us => us.Name.Contains(searchUser)))
//{
//    Console.WriteLine($"Id:{user.UserId} | ФИО:{user.Name}");
//}

//Задание 4
//Console.WriteLine("Введите кафе для поиска");
//string searcReviewForCafe = Console.ReadLine();
//var caf = context.Review
//    .Include(c => c.User)
//    .Include(c => c.Cafe)
//    .Where(c => c.Cafe.Name == searcReviewForCafe);
//foreach (var user in caf)
//{
//    string stars = "";
//    for (int i = 0; i < user.Stars; i++)
//    {
//        stars+= '*';
//    }
//    stars += "/*****";
//    Console.WriteLine($"ФИО {user.User.Name} | Кафе {user.Cafe.Name} | Оценка {stars}");
//}

//Задание 5
var groups = context.Review.Include(r => r.User).GroupBy(r => r.User);
var userMax = groups.First().Key;
var maxCount = groups.First().Count(r => r.Stars == 5);
foreach (var group in groups)
{
    var count = group.Count(r => r.Stars == 5);
    if (count > maxCount)
    {
        maxCount = count;
        userMax = group.Key;
    }
}

//Задание 9
Console.WriteLine("Введите id пользователя | кафе | число 1 - 5");
var idUs = Console.ReadLine();
var idCafe = Console.ReadLine();
var star = Console.ReadLine();
context.Review.Add(idUs, idCafe, DateTime.Now,star);