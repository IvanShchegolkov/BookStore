using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();

            ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    
                    new Book { Author = "Лев Толстой", Name = "Война и Мир", Category = "Роман", Price = 275, Description = "Потрясающая книга о Болконском, Безухове и Ростовой" },
                    new Book { Author = "Саймон Скэрроу", Name = "Катон и Макрон", Category = "Роман", Price = 300, Description = "История дружбы двух легионеров" },
                    new Book { Author = "Стивен Хокинг", Name = "Чёрные дыры", Category="Наука", Price=300, Description="Исследование черных дыр"},
                    new Book { Author = "Саймон Скэрроу", Name = "Заговор", Category = "Роман", Price = 300, Description = "Продолжение истории дружбы двух легионеров" },
                    new Book { Author = "Джордж Мартин", Name = "Песнь льда и пламени", Category = "Фантастика", Price = 200, Description="Потрясающая сага"}
                    );

                context.SaveChanges();
            }

           
        }
    }
}
