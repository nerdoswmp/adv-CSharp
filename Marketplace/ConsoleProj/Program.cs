using DAO;

using var context = new AppDbContext();
context.Database.EnsureCreated();


//context.address.Add(new Address
//{
//    city = "Araucária",
//    state = "Paraná",
//    country = "Brasil",
//    poste_code = "80010-110"
//});

context.client.Add(new Client
{
    address = new Address { street = "Leonardo Javorski", city = "Curitiba", state = "Paraná", country = "Brasil", postal_code = "81330-480" },
    email = "marceloalmeida12@email.com",
    phone = "41993822733",
    name = "marcelo",
    date_of_birth = new DateTime(1998, 10, 14),
    password = "coxinha123",
    document = "152.948.770-66",
    login = "xX_Marcelo_Xx"

});

context.client.Add(new Client
{
    address = new Address
    {
        street = "Lourenço Graboswki",
        city = "Araucária",
        state = "Paraná",
        country = "Brasil",
        postal_code = "80010-110"
    },
    email = "leosique2@email.com",
    phone = "41991830115",
    name = "leo",
    date_of_birth = new DateTime(2005, 12, 13),
    password = "astra_zeneka",
    document = "562.095.300-95",
    login = "LeoZique"

});
context.SaveChanges();

