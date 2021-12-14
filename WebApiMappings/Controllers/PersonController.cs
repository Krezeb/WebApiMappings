using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiMappings.Managers;

namespace WebApiMappings.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private static List<Person> _persons = new List<Person>(); 

        [HttpGet("{personId}")]
        public Person GetPerson(int personId)
        {
            return PersonManager.Instance.GetPerson(personId);
        }

        [HttpGet]
        public List<Person> ListPerson()
        {
            return PersonManager.Instance.List();
        }

        [HttpPost]
        public string CreatePerson([FromBody]Person person)
        {
            return PersonManager.Instance.Create(person);
        }
    }
}

/*
 * 
 * Nu är det dags att fixa till GetPerson. 
 * GetPerson ska hämta ut en specifik person ur vår persons-lista. 
 * För att kunna hämta ut en specifik person måste vi ha någon information som unikt identifierar personen. 
 * Namn kan ibland vara unikt men det är inte garanterat att vara det. 
 * Vi ska därför lägga till en property på Person som är unik för varje person.
 * 
 * Skapa en ny property på Person som heter Id och är av typen int. 
 * Id är en lite speciell property. 
 * Den ska inte sättas utanför klassen och den ska tilldelas ett värde som är unikt för varje ny person. 
 * Ange därför att property:n har get och private set så att vi bara kan ändra värdet inne i klassen. 
 * På så sätt förhindrar vi att någon extern utvecklare försöker ändra på värdet.
 * 
 * Vi måste också se till att sätta värdet på Id för varje person. 
 * Skapa därför först en konstruktor utan parametrar i Person. 
 * I konstruktorn ska vi sätta värdet på Id-property:n. 
 * Men vad ska vi sätta värdet till? 
 * En lösning som används i bland är att ha en static-variabel i en klass som räknas upp med 1 för varje instans som skapas. 
 * På sä sätt kan vi använda det nuvarande värdet som ett unikt Id för varje person som skapas.
 * 
 * Vänta med att skriva klart konstruktorn och skapa först en private static int som heter _idCounter. 
 * Sätt värdet på _idCounter till 0. 
 * Skriv sedan klart konstruktorn genom att sätta värdet på Id till det nuvarande värdet på _idCounter. 
 * Öka sedan värdet på _idCounter.
 * 
 * Med konstruktorn på plats kommer alla personer som skapas upp få ett unikt Id. 
 * Detta gäller även för personer som skapas upp med CreatePerson-metoden. 
 * Prova att köra programmet och skapa en person. 
 * Lista sedan personerna och notera att personen fått ett Id.
 * 
 * I PersonController, ändra så att GetPerson tar in en parameter av typen int. 
 * Namnge parametern personId. 
 * För att WebApi ska förstå att personId ska innehållet ett värde från sökvägen ,måste vi ändra värdet i attributet. 
 * Nu står det "get" i attributet. Ändra det till "{personId}". 
 * Genom att skriva så i attributet och samtidigt namnge parametern med samma namn kan WebApi matcha ihop dem.
 * 
 * Med den nya parametern personId kan vi nu skriva en loop i GetPerson som hittar den person som har motsvarande Id. 
 * Ändra koden i GetPerson så att den returnerar personen med det Id som skickats in. 
 * Om personen inte finns ska metoden returnera null.
 * 
 * Kör programmet. 
 * Skapa en person. 
 * Lista personerna för att se vilket Id personen fick. 
 * Använd sedan sökvägen /api/person/[ID] för att hämta just den personen.
 * 
 */