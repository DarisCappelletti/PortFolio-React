using System;
using System.Collections.Generic;

namespace PortFolio.Core.DAL.Models
{
    public class PostSoluzioneViaggio
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Grid
        {
            public string id { get; set; }
            public List<Summary> summaries { get; set; }
            public int selectedOfferId { get; set; }
            public int selectedServiceId { get; set; }
            public List<Service> services { get; set; }
            public List<object> infoMessages { get; set; }
            public bool canShowSeatMap { get; set; }
            public bool collapsedVisualization { get; set; }
            public bool regional { get; set; }
        }

        public class Message
        {
            public string imageId { get; set; }
            public string message { get; set; }
            public string status { get; set; }
        }

        public class MinPrice
        {
            public string currency { get; set; }
            public double amount { get; set; }
            public object originalAmount { get; set; }
            public bool indicative { get; set; }
        }

        public class Node
        {
            public string id { get; set; }
            public string origin { get; set; }
            public string destination { get; set; }
            public DateTime departureTime { get; set; }
            public DateTime arrivalTime { get; set; }
            public Train train { get; set; }
        }

        public class NodeService
        {
            public string denomination { get; set; }
            public string name { get; set; }
            public string offer { get; set; }
            public string service { get; set; }
        }

        public class Offer
        {
            public int offerId { get; set; }
            public int serviceId { get; set; }
            public string serviceName { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public Price price { get; set; }
            public List<object> discounts { get; set; }
            public int availableAmount { get; set; }
            public bool? canModify { get; set; }
            public bool? canChange { get; set; }
            public bool? canRefund { get; set; }
            public bool? isCartaFrecciaProgram { get; set; }
            public bool isInhibited { get; set; }
            public string status { get; set; }
            public List<object> infoMessages { get; set; }
            public ReportItemMessage reportItemMessage { get; set; }
            public List<Traveller> travellers { get; set; }
            public List<string> offerKeys { get; set; }
            public bool forceEvaluation { get; set; }
            public bool paidSeatSelection { get; set; }
            public bool selected { get; set; }
            public bool selecteable { get; set; }
        }

        public class Parameter
        {
            public int typeId { get; set; }
            public string name { get; set; }
            public string displayName { get; set; }
            public object value { get; set; }
            public List<object> allowedValues { get; set; }
            public bool required { get; set; }
            public bool readOnly { get; set; }
            public bool visible { get; set; }
            public string validationPattern { get; set; }
            public string inputPattern { get; set; }
            public int? minLength { get; set; }
            public int? maxLength { get; set; }
            public object maxValue { get; set; }
            public object minValue { get; set; }
            public string type { get; set; }
            public string flowType { get; set; }
            public string identity { get; set; }
            public object errorMessage { get; set; }
            public string info { get; set; }
        }

        public class Price
        {
            public string currency { get; set; }
            public double amount { get; set; }
            public object originalAmount { get; set; }
            public bool indicative { get; set; }
        }

        public class ReportItemMessage
        {
            public string imageId { get; set; }
            public string message { get; set; }
            public string status { get; set; }
        }

        public class RootPostSoluzioneViaggio
        {
            public string searchId { get; set; }
            public string cartId { get; set; }
            public List<object> highlightedMessages { get; set; }
            public List<PostSolution> solutions { get; set; }
            public List<object> minimumPrices { get; set; }
        }

        public class Service
        {
            public int id { get; set; }
            public string name { get; set; }
            public string shortName { get; set; }
            public string groupName { get; set; }
            public object description { get; set; }
            public string descriptionStandard { get; set; }
            public List<Offer> offers { get; set; }
            public MinPrice minPrice { get; set; }
            public int? bestOfferId { get; set; }
            public object extendedName { get; set; }
        }

        public class PostSolution
        {
            public PostSolution2 solution { get; set; }
            public List<Grid> grids { get; set; }
            public List<object> customizes { get; set; }
            public List<object> stopList { get; set; }
            public List<Message> messages { get; set; }
            public bool nextDaySolution { get; set; }
            public Tooltip tooltip { get; set; }
            public bool canShowSeatMap { get; set; }
            public bool notAllOfferGroupStandard { get; set; }
            public bool silenceArea { get; set; }
        }

        public class PostSolution2
        {
            public string _type { get; set; }
            public string id { get; set; }
            public string origin { get; set; }
            public string destination { get; set; }
            public DateTime departureTime { get; set; }
            public DateTime arrivalTime { get; set; }
            public string duration { get; set; }
            public string status { get; set; }
            public List<Train> trains { get; set; }
            public Price price { get; set; }
            public List<object> discounts { get; set; }
            public List<Node> nodes { get; set; }
        }

        public class Summary
        {
            public string name { get; set; }
            public string description { get; set; }
            public string duration { get; set; }
            public object highlightedMessage { get; set; }
            public bool urban { get; set; }
            public string departureLocationName { get; set; }
            public string arrivalLocationName { get; set; }
            public DateTime departureTime { get; set; }
            public DateTime arrivalTime { get; set; }
            public TrainInfo trainInfo { get; set; }
        }

        public class Tooltip
        {
            public List<NodeService> nodeServices { get; set; }
            public double loyaltyPoints { get; set; }
            public int regionalLoyaltyPoints { get; set; }
        }

        public class Train
        {
            public string trainCategory { get; set; }
            public string acronym { get; set; }
            public string denomination { get; set; }
            public string name { get; set; }
            public string logoId { get; set; }
            public bool urban { get; set; }
        }

        public class Train2
        {
            public string trainCategory { get; set; }
            public string acronym { get; set; }
            public string denomination { get; set; }
            public string name { get; set; }
            public string logoId { get; set; }
            public bool urban { get; set; }
        }

        public class TrainInfo
        {
            public string trainCategory { get; set; }
            public string acronym { get; set; }
            public string denomination { get; set; }
            public string name { get; set; }
            public string logoId { get; set; }
            public bool urban { get; set; }
        }

        public class Traveller
        {
            public string id { get; set; }
            public object firstName { get; set; }
            public object lastName { get; set; }
            public object loyaltyCode { get; set; }
            public object customerKey { get; set; }
            public List<Parameter> parameters { get; set; }
            public object loyaltyPoints { get; set; }
            public object regionalLoyaltyPoints { get; set; }
            public bool showCFBalanceLink { get; set; }
            public bool showREGBalanceLink { get; set; }
            public bool adult { get; set; }
            public object loyaltyGiftCardBeneficiary { get; set; }
        }
    }
}