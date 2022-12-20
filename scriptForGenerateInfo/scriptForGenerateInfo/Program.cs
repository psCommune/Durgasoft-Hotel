using Bogus;

Faker <Client> faker = new Faker<Client>("ru");
var clients = faker
    .RuleFor(c => c.FullName, r => r.Person.FullName)
    .RuleFor(c => c.Phone, r => r.Person.Phone)
    .GenerateLazy(2000).ToList();

using (var sw = new StreamWriter("clients.csv"))
{
    foreach(Client client in clients)
    {
        sw.WriteLine($"{client.FullName};{client.Phone}");
    }
}



class Client
{
    public string FullName { get; set; } = "";

    public string Phone { get; set; } = "";
}