using XMLExternalEntity.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace XMLExternalEntity.Utility
{
    public class OfferParser
    {
        public static List<Offer> GetOffers(Stream input)
        {
            List<Offer> offers = new List<Offer>();

            XmlReader xmlReader = XmlReader.Create(input);

            var root = XDocument.Load(xmlReader, LoadOptions.PreserveWhitespace);

            foreach (var offerElement in root.Root.Elements("offer"))
            {
                Offer anOffer = new Offer();
                anOffer.ID = (string)offerElement.Element("id");
                anOffer.Title = (string)offerElement.Element("title");
                anOffer.Reference = (string)offerElement.Element("reference");
                anOffer.Total = (int)offerElement.Element("total");
                offers.Add(anOffer);
            }

            return offers;
        }
    }
}