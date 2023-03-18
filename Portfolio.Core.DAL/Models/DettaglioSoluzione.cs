using System;
using System.Collections.Generic;

namespace PortFolio.Core.DAL.Models
{
    public class DettaglioSoluzione
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class AllowedValue
        {
            public string key { get; set; }
            public string value { get; set; }
        }

        public class Cashback
        {
            public object info { get; set; }
            public object applied { get; set; }
        }

        public class NodeSummary
        {
            public NodeView nodeView { get; set; }
            public object pnr { get; set; }
            public object travelId { get; set; }
            public Price price { get; set; }
            public List<OfferContainerSummaryView> offerContainerSummaryViews { get; set; }
            public List<object> messages { get; set; }
            public bool caneDbrAncillary { get; set; }
            public bool changed { get; set; }
        }

        public class NodeView
        {
            public string id { get; set; }
            public string origin { get; set; }
            public string destination { get; set; }
            public DateTime departureTime { get; set; }
            public DateTime arrivalTime { get; set; }
            public Train train { get; set; }
        }

        public class OfferContainerSummaryView
        {
            public bool adults { get; set; }
            public string serviceName { get; set; }
            public string offerName { get; set; }
            public bool regional { get; set; }
            public List<OfferSummaryView> offerSummaryViews { get; set; }
        }

        public class OfferSummaryView
        {
            public object resourceId { get; set; }
            public Traveller traveller { get; set; }
            public int serviceId { get; set; }
            public string serviceName { get; set; }
            public string serviceDescription { get; set; }
            public int offerId { get; set; }
            public string offerName { get; set; }
            public object cpCode { get; set; }
            public object idTravel { get; set; }
            public object entitlementId { get; set; }
            public bool seatNotAssigned { get; set; }
            public Price price { get; set; }
            public object appliedPromo { get; set; }
            public object selfCheckIn { get; set; }
            public bool forcedSelected { get; set; }
            public Cashback cashback { get; set; }
            public string id { get; set; }
            public string offerDescritpion { get; set; }
            public List<object> seatInfo { get; set; }
        }

        public class OtherServices
        {
            public object totalPrice { get; set; }
            public List<object> ancillaries { get; set; }
            public List<object> hiddenAncillaries { get; set; }
            public List<object> additionalFees { get; set; }
        }

        public class Parameter
        {
            public int typeId { get; set; }
            public string name { get; set; }
            public string displayName { get; set; }
            public string value { get; set; }
            public List<AllowedValue> allowedValues { get; set; }
            public bool required { get; set; }
            public bool readOnly { get; set; }
            public bool visible { get; set; }
            public object validationPattern { get; set; }
            public object inputPattern { get; set; }
            public object minLength { get; set; }
            public object maxLength { get; set; }
            public object maxValue { get; set; }
            public object minValue { get; set; }
            public string type { get; set; }
            public string flowType { get; set; }
            public string identity { get; set; }
            public object errorMessage { get; set; }
            public object info { get; set; }
        }

        public class Price
        {
            public string currency { get; set; }
            public double amount { get; set; }
            public object originalAmount { get; set; }
            public bool indicative { get; set; }
        }

        public class RootSoluzioni
        {
            public string _type { get; set; }
            public string id { get; set; }
            public string origin { get; set; }
            public string destination { get; set; }
            public DateTime departureTime { get; set; }
            public DateTime arrivalTime { get; set; }
            public string duration { get; set; }
            public List<SolutionContainer> solutionContainers { get; set; }
            public object solutionToChange { get; set; }
            public List<SolutionPreview> solutionPreviews { get; set; }
            public string status { get; set; }
            public object expirationDate { get; set; }
            public List<object> latestSolutionIds { get; set; }
            public List<string> temporarySolutionIds { get; set; }
            public TotalPrice totalPrice { get; set; }
            public string totalPriceCrypted { get; set; }
            public List<object> additionalFees { get; set; }
        }

        public class SolutionContainer
        {
            public string _type { get; set; }
            public string id { get; set; }
            public object resourceId { get; set; }
            public SolutionSummary solutionSummary { get; set; }
            public List<NodeSummary> nodeSummaries { get; set; }
            public OtherServices otherServices { get; set; }
            public bool addToCalendar { get; set; }
            public object returnSolutionContainer { get; set; }
            public TotalPrice totalPrice { get; set; }
            public List<object> termsAndConditions { get; set; }
        }

        public class SolutionPreview
        {
            public string id { get; set; }
            public string header { get; set; }
            public object subheader { get; set; }
            public string title { get; set; }
            public string subtitle { get; set; }
            public TotalPrice totalPrice { get; set; }
        }

        public class SolutionSummary
        {
            public string id { get; set; }
            public int originId { get; set; }
            public string origin { get; set; }
            public int destinationId { get; set; }
            public string destination { get; set; }
            public DateTime departureTime { get; set; }
            public DateTime arrivalTime { get; set; }
            public int adults { get; set; }
            public int children { get; set; }
            public TotalPrice totalPrice { get; set; }
            public object description { get; set; }
            public object ancillaryCovidFree { get; set; }
            public bool roundTrip { get; set; }
        }

        public class TotalPrice
        {
            public string currency { get; set; }
            public double amount { get; set; }
            public object originalAmount { get; set; }
            public bool indicative { get; set; }
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

        public class Traveller
        {
            public string id { get; set; }
            public object firstName { get; set; }
            public object lastName { get; set; }
            public object loyaltyCode { get; set; }
            public object customerKey { get; set; }
            public List<Parameter> parameters { get; set; }
            public double loyaltyPoints { get; set; }
            public int regionalLoyaltyPoints { get; set; }
            public bool showCFBalanceLink { get; set; }
            public bool showREGBalanceLink { get; set; }
            public bool adult { get; set; }
            public object loyaltyGiftCardBeneficiary { get; set; }
        }


    }
}