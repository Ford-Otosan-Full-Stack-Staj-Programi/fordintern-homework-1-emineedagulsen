FordIntern-v1
Asagida verilen modeli kullanarak GetAll, GetById , Put , Post , Delete methodlarini icen
bir controller implement ediniz.
EF ile generic repository ve UnitOfWork kullanabilirsiniz. (Opsiyonel)
Put  ve Post apilerin de model validation hazirlayiniz.  Fluent validation kullaniniz.
Extra olarak 2 tane alana gore (Query parameter) filtreleme yapan Filter apisi ekleyiniz
(GET) ve WHERE sarti ile database den filtreleme yapiniz.
SOLID e uymaya ozen gosteriniz .
Proje icerisinde sadece odev ile ilgili kisimlara yer veriniz. Kullanilmayan controller ve
methodlari gondermeyiniz.
 
                                public class Staff 
                                   {
                                   public int Id { get; set; }
                                   public string CreatedBy { get; set; }
                                   public DateTime CreatedAt { get; set; }
                                   public string FirstName { get; set; }
                                   public string LastName { get; set; }
                                   public string Email { get; set; }
                                   public string Phone { get; set; }
                                   public DateTime DateOfBirth { get; set; }
                                   public string AddressLine1 { get; set; }
                                   public string City { get; set; }
                                   public string Country { get; set; }
                                   public string Province { get; set; }
                                   [NotMapped]
                                   public string FullName
                                   {
                                       get { return FirstName +   + LastName; }
                                   }
                                }

Ödevinizin teslim tarihi 24.03.2023 saat 23.59 
