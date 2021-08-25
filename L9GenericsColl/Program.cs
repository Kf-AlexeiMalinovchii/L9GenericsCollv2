using L9GenericsColl.Entities;
using L9GenericsColl.Enums;
using L9GenericsColl.Repositories;
using L9GenericsColl.DbContexts;
using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace L9GenericsColl
{
    class Program
    {
       public class Device
        {
            public string Name { get; set; }
            public string Firm { get; set; }

            public User UserHandelr { get; set; }
        }
        static void Main(string[] args)
        {

           

            List <Gamer> list= new List<Gamer>(40);
           // List<Device> list2 = new List<Device>(10);
            Gamer user = new Gamer();
            //user.Id = 1;
            user.Name = "Alex";
            user.State = UserState.Admin;
            user.PhoneNumber = "079975524";
            Gamer user2 = new Gamer();
           // user2.Id = 2;
            user2.Name = "John";
            user2.State = UserState.Gamer;
            user2.PhoneNumber = "079975222";
            Gamer user3 = new Gamer();
          //  user3.Id = 3;
            user3.Name = "Jade";
            user3.State = UserState.Gamer;
            user3.PhoneNumber = "069529388";
            Gamer user4 = new Gamer();
            user4.Id = 4;
            user4.Name = "Kate";
            user4.State = UserState.Gamer;
            user4.PhoneNumber = "079975222";
            Gamer user5 = new Gamer();
            user5.Id = 5;
            user5.Name = "Nick";
            user5.State = UserState.Moder;
            user5.PhoneNumber = "068228322";
            Gamer user6 = new Gamer();
            user6.Id = 6;
            user6.Name = "Alex";
            user6.State = UserState.Gamer;
            user6.PhoneNumber = "079975111";
            //Device device = new Device() { Name = "Mouse G103", Firm = "Logitech", UserHandelr=user };
            //Device device2 = new Device() { Name = "Mouse G403", Firm = "Logitech", UserHandelr = user2 };
            //Device device3 = new Device() { Name = "Keyboard S201", Firm = "Defender",  UserHandelr = user3 };


            MyGameDbContext context = new MyGameDbContext();


            context.Database.EnsureCreated();

            //context.Gamers.Add(user);
         
            //context.Gamers.Add(user2);
            //context.Gamers.Add(user3);
            
           // context.SaveChanges();

            GamerRepository efRepos = new GamerRepository(context);
          
            efRepos.Add(user);
            efRepos.Add(user2);
            efRepos.Add(user3);

              var item = efRepos.TryGetById(1);
             Console.WriteLine(item.Id + " " + item.Status + " "  );
            user2.Name = "Alex2";
            user2.State = UserState.Moder;
            efRepos.Update(user2);
             // foreach (var itm in efRepos.GetAll())
             // {
             //     Console.WriteLine(itm.Id + " " + itm.Name + " " + itm.PhoneNumber);
             // }
              efRepos.Remove(user2);
             //foreach (var itm in efRepos.GetAll())
             //{
             //    Console.WriteLine(itm.Id + " " + itm.Name + " " + itm.PhoneNumber);
             //}
            context.SaveChanges();

            //  efRepos.Add(user4);
            //  efRepos.Add(user5);
            //  efRepos.Add(user6);


            //  list.Add(user);
            //  list.Add(user2);
            //  list.Add(user3);
            //  list.Add(user4);
            //  list.Add(user5);
            //  list.Add(user6);

            //  //list2.Add(device);
            //  //list2.Add(device2);
            //  //list2.Add(device3);
            //  BaseRepository<Gamer> st = new BaseRepository<Gamer>();
            ////  User user2 = new User();
            // // user2.Id = 2;
            ////  user2.Name = "Alex2";
            // // user2.State = UserState.Moder;



            //efRepos.CompareId(user, user2);




            //  var item = efRepos.GetById(1);
            //  Console.WriteLine(item.Id + " " + item.Name + " " + item.PhoneNumber);

            //  efRepos.Update(user);
            //  foreach (var itm in efRepos.GetAll())
            //  {
            //      Console.WriteLine(itm.Id + " " + itm.Name + " " + itm.PhoneNumber);
            //  }
            //  efRepos.Remove(user);
            //  foreach (var itm in efRepos.GetAll())
            //  {
            //      Console.WriteLine(itm.Id + " " + itm.Name + " " + itm.PhoneNumber);
            //  }

            // var query = from u in list where u.State == UserState.Gamer select u;
            // var query2 = list.Where(u => u.Name.Contains("Alex"))
            //     .OrderByDescending(u => u.Id)
            //     .Take(2);
            // var query3 = list.Where(u => u.Name.StartsWith("J"))
            // .OrderBy(u => u.Id)
            // .ThenBy(u=>u.Name)
            // .Reverse()
            // .Skip(1)
            // .Take(2);
            // var query4 = from u in list where u.Name.Length>3 orderby u.Id  select u;

            // var query5 = list.TakeWhile(u => u.Id < 5);

            // var query6 = list.Select(u => u.Name);
            // var query7 = list.SelectMany(u => u.Name);
            // var query8 = from u in list
            //              select new
            //              {
            //                  u.Name,
            //                  Id = u.Id
            //              };

            // var query9 = list.Join(list2, users => users, d=>d.UserHandelr, (users, d) => new { UserName = users.Name, DeviceName = d.Name });

            // // var query10= list.GroupJoin(list2, )

            // var query10 = list.Zip(list2).GroupBy(u=>u.First.Name + u.Second.Name);

            // var query11 = list.Concat(list);
            // var query12 = list.Union(query11);
            // var query13 = list.Intersect(list);
            // var query14 = query11.Except(query12);
            // var query15 = list.ToArray();
            // var query16 = list.OfType<Gamer>().First();

            // var query17 = list.Aggregate(0, (indx, n) => indx + n.Id);

            // var query18 = list.Where(u => u.Id == 2) ?? Enumerable.Empty<Gamer>();

            // foreach (var u in query5)
            // {
            //     Console.WriteLine(u.Id + " " + u.Name + " " + u.PhoneNumber);
            // }
            // foreach (var u in query6)
            // {
            //     Console.WriteLine(u);
            // }
            // foreach (var u in query9)
            // {
            //     Console.WriteLine(u.UserName + " " + u.DeviceName);
            // }

            // foreach (var u in query10)
            // {
            //     Console.WriteLine(u.Key);
            // }

            //var del= SomeFunc();
            // Console.WriteLine(del(1));
            // Console.WriteLine(del(1));
            // Console.WriteLine(del(1));

            // static Func<int, int> SomeFunc() {
            //     var someVar = 1;

            //     Console.WriteLine(someVar);
            //     Console.WriteLine("Outside");
            //     Func<int, int> inc = delegate (int var1)
            //     {
            //         Console.WriteLine(someVar);
            //         Console.WriteLine("InsideSomeFunc");
            //         someVar = someVar + 1;
            //         return var1 + someVar;
            //     };
            //     return inc;


            // }


        }
    }
}
