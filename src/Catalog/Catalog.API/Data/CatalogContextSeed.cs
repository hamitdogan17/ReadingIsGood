using Catalog.API.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name = "The Brothers Karamazov",
                    Author = "Fyodor Mihayloviç Dostoyevski",
                    Description = "The Brothers Karamasov is a murder mystery, a courtroom drama, and an exploration of erotic rivalry in a series of triangular love affairs involving the “wicked and sentimental” Fyodor Pavlovich Karamazov and his three sons―the impulsive and sensual Dmitri; the coldly rational Ivan; and the healthy, red-cheeked young novice Alyosha. Through the gripping events of their story, Dostoevsky portrays the whole of Russian life, is social and spiritual striving, in what was both the golden age and a tragic turning point in Russian culture.",
                    ImageFile = "product-1.png",
                    Price = 15.99M,
                    Category = "Philosophical novel Theological fiction"
                },
                new Product()
                {
                    Name = "The Count of Monte Cristo",
                    Author = " Alexandre Dumas père",
                    Description = "Thrown in prison for a crime he has not committed, Edmond Dantes is confined to the grim fortress of If. There he learns of a great hoard of treasure hidden on the Isle of Monte Cristo and he becomes determined not only to escape, but also to unearth the treasure and use it to plot the destruction of the three men responsible for his incarceration. Dumas’ epic tale of suffering and retribution, inspired by a real-life case of wrongful imprisonment, was a huge popular success when it was first serialized in the 1840s.",
                    ImageFile = "product-2.png",
                    Price = 9.99M,
                    Category = "Historical novel; ‎Adventure"
                },
                new Product()
                {
                    Name = "Pere Goriot",
                    Author = "Honoré de Balzac",
                    Description = "This fine example of the French realist novel contrasts the social progress of an impoverished but ambitious aristocrat with the tale of a father, whose obsessive love for his daughters leads to his personal and financial ruin.",
                    ImageFile = "product-3.png",
                    Price = 12.450M,
                    Category = "Novel, Fiction"
                },
                new Product()
                {
                    Name = "Eugénie Grandet",
                    Author = "Honoré de Balzac",
                    Description = "This is the question that fills the minds of the inhabitants of Saumur, the setting for Eugénie Grandet (1833), one of the earliest and most famous novels in Balzac's Comédie humaine. The Grandet household, oppressed by the exacting miserliness of Grandet himself, is jerked violently out of routine by the sudden arrival of Eugénie's cousin Charles, recently orphaned and penniless. Eugénie's emotional awakening, stimulated by her love for her cousin, brings her into direct conflict with her father, whose cunning and financial success are matched against her determination to rebel.",
                    ImageFile = "product-4.png",
                    Price = 13.95M,
                    Category = "Novel, Fiction"
                },
                new Product()
                {
                    Name = "Dead Souls",
                    Author = "Nikolai Gogol", 
                    Description = "Since its publication in 1842, Dead Souls has been celebrated as a supremely realistic portrait of provincial Russian life and as a splendidly exaggerated tale; as a paean to the Russian spirit and as a remorseless satire of imperial Russian venality, vulgarity, and pomp. As Gogol's wily antihero, Chichikov, combs the back country wheeling and dealing for 'dead souls'--deceased serfs who still represent money to anyone sharp enough to trade in them--we are introduced to a Dickensian cast of peasants, landowners, and conniving petty officials, few of whom can resist the seductive illogic of Chichikov's proposition. This lively, idiomatic English version by the award-winning translators Richard Pevear and Larissa Volokhonsky makes accessible the full extent of the novel's lyricism, sulphurous humor, and delight in human oddity and error.",
                    ImageFile = "product-5.png",
                    Price = 10.90M,
                    Category = "Picaresque, ‎political‎, ‎satire"
                },
                new Product()
                {
                    Name = "The Gambler",
                    Author = "Fyodor Mihayloviç Dostoyevski",
                    Description = "A new, beautifully laid-out, easy-to-read edition of Fyodor Dostoevsky's 1867 classic. This edition is based on a translation by C.J. Hogarth (1869-1942), originally published in 1917",
                    ImageFile = "product-6.png",
                    Price = 7.90M,
                    Category = "Home Kitchen"
                }
            };
        }
    }
}
