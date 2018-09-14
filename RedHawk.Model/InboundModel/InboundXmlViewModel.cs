using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;


namespace RedHawk.Model.InboundModel
{
    public class InboundXmlViewModel
    {
        [XmlRoot(ElementName = "policy_holder")]
        public class Policy_holder
        {

            [XmlElement(ElementName = "policy_holder_first_name")]
            public string Policy_holder_first_name { get; set; }
            [XmlElement(ElementName = "policy_holder_middle_initial")]
            public string Policy_holder_middle_initial { get; set; }
            [XmlElement(ElementName = "policy_holder_last_name")]
            public string Policy_holder_last_name { get; set; }
            [XmlElement(ElementName = "policy_holder_home_phone")]
            public string Policy_holder_home_phone { get; set; }
            [XmlElement(ElementName = "policy_holder_work_phone")]
            public string Policy_holder_work_phone { get; set; }
            [XmlElement(ElementName = "policy_holder_cell_phone")]
            public string Policy_holder_cell_phone { get; set; }
            [XmlElement(ElementName = "policy_holder_email")]
            public string Policy_holder_email { get; set; }
        }

        [XmlRoot(ElementName = "co_policy_holder")]
        public class Co_policy_holder
        {
            [XmlElement(ElementName = "policy_holder_first_name")]
            public string Policy_holder_first_name { get; set; }
            [XmlElement(ElementName = "policy_holder_middle_initial")]
            public string Policy_holder_middle_initial { get; set; }
            [XmlElement(ElementName = "policy_holder_last_name")]
            public string Policy_holder_last_name { get; set; }
            [XmlElement(ElementName = "policy_holder_home_phone")]
            public string Policy_holder_home_phone { get; set; }
            [XmlElement(ElementName = "policy_holder_work_phone")]
            public string Policy_holder_work_phone { get; set; }
            [XmlElement(ElementName = "policy_holder_cell_phone")]
            public string Policy_holder_cell_phone { get; set; }
            [XmlElement(ElementName = "policy_holder_email")]
            public string Policy_holder_email { get; set; }
        }

        [XmlRoot(ElementName = "risk_address")]
        public class Risk_address
        {
            [XmlElement(ElementName = "address_line_1")]
            public string Address_line_1 { get; set; }
            [XmlElement(ElementName = "address_line_2")]
            public string Address_line_2 { get; set; }
            [XmlElement(ElementName = "city")]
            public string City { get; set; }
            [XmlElement(ElementName = "county")]
            public string County { get; set; }
            [XmlElement(ElementName = "state_or_province")]
            public string State_or_province { get; set; }
            [XmlElement(ElementName = "zip_code")]
            public string Zip_code { get; set; }
            [XmlElement(ElementName = "country")]
            public string Country { get; set; }
            [XmlElement(ElementName = "rating_territory")]
            public string Rating_territory { get; set; }
        }

        [XmlRoot(ElementName = "policy_holder_mailing_address")]
        public class Policy_holder_mailing_address
        {
            [XmlElement(ElementName = "address_line_1")]
            public string Address_line_1 { get; set; }
            [XmlElement(ElementName = "address_line_2")]
            public string Address_line_2 { get; set; }
            [XmlElement(ElementName = "city")]
            public string City { get; set; }
            [XmlElement(ElementName = "county")]
            public string County { get; set; }
            [XmlElement(ElementName = "state_or_province")]
            public string State_or_province { get; set; }
            [XmlElement(ElementName = "zip_code")]
            public string Zip_code { get; set; }
            [XmlElement(ElementName = "country")]
            public string Country { get; set; }
            [XmlElement(ElementName = "rating_territory")]
            public string Rating_territory { get; set; }
        }

        [XmlRoot(ElementName = "coverage_limits")]
        public class Coverage_limits
        {
            [XmlElement(ElementName = "coverage_a_limit")]
            public string Coverage_a_limit { get; set; }
            [XmlElement(ElementName = "coverage_c_limit")]
            public string Coverage_c_limit { get; set; }
            [XmlElement(ElementName = "coverage_d_limit")]
            public string Coverage_d_limit { get; set; }
            [XmlElement(ElementName = "coverage_e_limit")]
            public string Coverage_e_limit { get; set; }
            [XmlElement(ElementName = "building_code_upgrade_limit")]
            public string Building_code_upgrade_limit { get; set; }
            [XmlElement(ElementName = "coverage_a_deductible")]
            public string Coverage_a_deductible { get; set; }
            [XmlElement(ElementName = "coverage_c_deductible")]
            public string Coverage_c_deductible { get; set; }
            [XmlElement(ElementName = "coverage_e_deductible")]
            public string Coverage_e_deductible { get; set; }
            [XmlElement(ElementName = "coverage_a_masonry_option")]
            public string Coverage_a_masonry_option { get; set; }
            [XmlElement(ElementName = "coverage_c_breakable_option")]
            public string Coverage_c_breakable_option { get; set; }
        }

        [XmlRoot(ElementName = "written_premium")]
        public class Written_premium
        {
            [XmlElement(ElementName = "transaction_premium_written")]
            public string Transaction_premium_written { get; set; }
            [XmlElement(ElementName = "transaction_agent_commission")]
            public string Transaction_agent_commission { get; set; }
            [XmlElement(ElementName = "transaction_operating_cost")]
            public string Transaction_operating_cost { get; set; }
            [XmlElement(ElementName = "transaction_net_premium")]
            public string Transaction_net_premium { get; set; }
        }

        [XmlRoot(ElementName = "homeowners")]
        public class Homeowners
        {
            [XmlElement(ElementName = "property_inspection_indicator")]
            public string Property_inspection_indicator { get; set; }
            [XmlElement(ElementName = "property_inspection_date")]
            public string Property_inspection_date { get; set; }
            [XmlElement(ElementName = "chimneys")]
            public string Chimneys { get; set; }
            [XmlElement(ElementName = "year_of_construction")]
            public string Year_of_construction { get; set; }
            [XmlElement(ElementName = "roof_type")]
            public string Roof_type { get; set; }
            [XmlElement(ElementName = "construction_type")]
            public string Construction_type { get; set; }
            [XmlElement(ElementName = "square_footage")]
            public string Square_footage { get; set; }
            [XmlElement(ElementName = "number_stories")]
            public string Number_stories { get; set; }
            [XmlElement(ElementName = "unrepaired_eq_damage")]
            public string Unrepaired_eq_damage { get; set; }
            [XmlElement(ElementName = "cripple_walls")]
            public string Cripple_walls { get; set; }
            [XmlElement(ElementName = "cripple_walls_braced")]
            public string Cripple_walls_braced { get; set; }
            [XmlElement(ElementName = "hazard_discount")]
            public string Hazard_discount { get; set; }
            [XmlElement(ElementName = "water_heater_secured")]
            public string Water_heater_secured { get; set; }
            [XmlElement(ElementName = "secured_to_foundation")]
            public string Secured_to_foundation { get; set; }
            [XmlElement(ElementName = "foundation_type")]
            public string Foundation_type { get; set; }
            [XmlElement(ElementName = "product_type")]
            public string Product_type { get; set; }
            [XmlElement(ElementName = "post_and_pier")]
            public string Post_and_pier { get; set; }
            [XmlElement(ElementName = "post_and_pier_modified")]
            public string Post_and_pier_modified { get; set; }
        }

        [XmlRoot(ElementName = "manufactured_mobile")]
        public class Manufactured_mobile
        {
            [XmlElement(ElementName = "property_inspection_indicator")]
            public string Property_inspection_indicator { get; set; }
            [XmlElement(ElementName = "property_inspection_date")]
            public string Property_inspection_date { get; set; }
            [XmlElement(ElementName = "year_of_construction")]
            public string Year_of_construction { get; set; }
            [XmlElement(ElementName = "square_footage")]
            public string Square_footage { get; set; }
            [XmlElement(ElementName = "unrepaired_eq_damage")]
            public string Unrepaired_eq_damage { get; set; }
            [XmlElement(ElementName = "earthquake_resistant_bracing_system")]
            public string Earthquake_resistant_bracing_system { get; set; }
            [XmlElement(ElementName = "product_type")]
            public string Product_type { get; set; }
        }

        [XmlRoot(ElementName = "condominium")]
        public class Condominium
        {
            [XmlElement(ElementName = "number_stories")]
            public string Number_stories { get; set; }
        }

        [XmlRoot(ElementName = "rating_factors")]
        public class Rating_factors
        {
            [XmlElement(ElementName = "homeowners")]
            public Homeowners Homeowners { get; set; }
            [XmlElement(ElementName = "manufactured_mobile")]
            public Manufactured_mobile Manufactured_mobile { get; set; }
            [XmlElement(ElementName = "condominium")]
            public Condominium Condominium { get; set; }
            [XmlElement(ElementName = "renters")]
            public string Renters { get; set; }
        }

        [XmlRoot(ElementName = "agency_mailing_address")]
        public class Agency_mailing_address
        {
            [XmlElement(ElementName = "address_line_1")]
            public string Address_line_1 { get; set; }
            [XmlElement(ElementName = "address_line_2")]
            public string Address_line_2 { get; set; }
            [XmlElement(ElementName = "city")]
            public string City { get; set; }
            [XmlElement(ElementName = "county")]
            public List<string> County { get; set; }
            [XmlElement(ElementName = "state_or_province")]
            public string State_or_province { get; set; }
            [XmlElement(ElementName = "zip_code")]
            public string Zip_code { get; set; }
            [XmlElement(ElementName = "country")]
            public string Country { get; set; }
        }

        [XmlRoot(ElementName = "agency")]
        public class Agency
        {
            [XmlElement(ElementName = "agency_id")]
            public string Agency_id { get; set; }
            [XmlElement(ElementName = "agency_name")]
            public string Agency_name { get; set; }
            [XmlElement(ElementName = "agency_phone")]
            public string Agency_phone { get; set; }
            [XmlElement(ElementName = "agency_tax_id")]
            public string Agency_tax_id { get; set; }
            [XmlElement(ElementName = "servicing_producer_id")]
            public string Servicing_producer_id { get; set; }
            [XmlElement(ElementName = "agency_mailing_address")]
            public Agency_mailing_address Agency_mailing_address { get; set; }
        }

        [XmlRoot(ElementName = "policy")]
        public class Policy
        {
            [XmlElement(ElementName = "policy_holder")]
            public Policy_holder Policy_holder { get; set; }
            [XmlElement(ElementName = "co_policy_holder")]
            public Co_policy_holder Co_policy_holder { get; set; }
            [XmlElement(ElementName = "policy_expiration_date")]
            public string Policy_expiration_date { get; set; }
            [XmlElement(ElementName = "companion_policy_type")]
            public string Companion_policy_type { get; set; }
            [XmlElement(ElementName = "companion_policy_number")]
            public string Companion_policy_number { get; set; }
            [XmlElement(ElementName = "external_policy_source")]
            public string External_policy_source { get; set; }
            [XmlElement(ElementName = "companion_policy_status")]
            public string Companion_policy_status { get; set; }
            [XmlElement(ElementName = "occupancy_type")]
            public string Occupancy_type { get; set; }
            [XmlElement(ElementName = "risk_address")]
            public Risk_address Risk_address { get; set; }
            [XmlElement(ElementName = "mailing_same_as_risk_address")]
            public string Mailing_same_as_risk_address { get; set; }
            [XmlElement(ElementName = "policy_holder_mailing_address")]
            public Policy_holder_mailing_address Policy_holder_mailing_address { get; set; }
            [XmlElement(ElementName = "agent_license_number")]
            public string Agent_license_number { get; set; }
            [XmlElement(ElementName = "billing_plan")]
            public string Billing_plan { get; set; }
            [XmlElement(ElementName = "coverage_limits")]
            public Coverage_limits Coverage_limits { get; set; }
            [XmlElement(ElementName = "written_premium")]
            public Written_premium Written_premium { get; set; }
            [XmlElement(ElementName = "rating_factors")]
            public Rating_factors Rating_factors { get; set; }
            [XmlElement(ElementName = "agency")]
            public Agency Agency { get; set; }
            [XmlElement(ElementName = "renewal_status")]
            public string Renewal_status { get; set; }
            [XmlElement(ElementName = "pi_use")]
            public string Pi_use { get; set; }
        }

        [XmlRoot(ElementName = "new_business")]
        public class New_business
        {
            [XmlElement(ElementName = "policy")]
            public Policy Policy { get; set; }
            [XmlAttribute(AttributeName = "transaction_id")]
            public string Transaction_id { get; set; }
            [XmlAttribute(AttributeName = "transaction_effective_date")]
            public string Transaction_effective_date { get; set; }
            [XmlAttribute(AttributeName = "correcting_transaction_id")]
            public string Correcting_transaction_id { get; set; }
            [XmlAttribute(AttributeName = "previous_policy_number")]
            public string Previous_policy_number { get; set; }
        }
        [XmlRoot(ElementName = "endorsement")]
        public class Endorsement
        {
            [XmlElement(ElementName = "policy")]
            public Policy Policy { get; set; }
            [XmlAttribute(AttributeName = "transaction_id")]
            public string Transaction_id { get; set; }
            [XmlAttribute(AttributeName = "transaction_effective_date")]
            public string Transaction_effective_date { get; set; }
            [XmlAttribute(AttributeName = "correcting_transaction_id")]
            public string Correcting_transaction_id { get; set; }
            [XmlAttribute(AttributeName = "previous_policy_number")]
            public string Previous_policy_number { get; set; }
        }
        [XmlRoot(ElementName = "policy_cancellation")]
        public class PolicyCancellation
        {
            [XmlElement(ElementName = "policy")]
            public Policy Policy { get; set; }
            [XmlAttribute(AttributeName = "transaction_id")]
            public string Transaction_id { get; set; }
            [XmlAttribute(AttributeName = "transaction_effective_date")]
            public string Transaction_effective_date { get; set; }
            [XmlAttribute(AttributeName = "correcting_transaction_id")]
            public string Correcting_transaction_id { get; set; }
            [XmlAttribute(AttributeName = "previous_policy_number")]
            public string Previous_policy_number { get; set; }
        }
        [XmlRoot(ElementName = "reinstatement")]
        public class Reinstatement
        {
            [XmlElement(ElementName = "policy")]
            public Policy Policy { get; set; }
            [XmlAttribute(AttributeName = "transaction_id")]
            public string Transaction_id { get; set; }
            [XmlAttribute(AttributeName = "transaction_effective_date")]
            public string Transaction_effective_date { get; set; }
            [XmlAttribute(AttributeName = "correcting_transaction_id")]
            public string Correcting_transaction_id { get; set; }
            [XmlAttribute(AttributeName = "previous_policy_number")]
            public string Previous_policy_number { get; set; }
        }
        [XmlRoot(ElementName = "reissue")]
        public class Reissue
        {
            [XmlElement(ElementName = "policy")]
            public Policy Policy { get; set; }
            [XmlAttribute(AttributeName = "transaction_id")]
            public string Transaction_id { get; set; }
            [XmlAttribute(AttributeName = "transaction_effective_date")]
            public string Transaction_effective_date { get; set; }
            [XmlAttribute(AttributeName = "correcting_transaction_id")]
            public string Correcting_transaction_id { get; set; }
            [XmlAttribute(AttributeName = "previous_policy_number")]
            public string Previous_policy_number { get; set; }
        }
        [XmlRoot(ElementName = "renewal")]
        public class Renewal
        {
            [XmlElement(ElementName = "policy")]
            public Policy Policy { get; set; }
            [XmlAttribute(AttributeName = "transaction_id")]
            public string Transaction_id { get; set; }
            [XmlAttribute(AttributeName = "transaction_effective_date")]
            public string Transaction_effective_date { get; set; }
            [XmlAttribute(AttributeName = "correcting_transaction_id")]
            public string Correcting_transaction_id { get; set; }
            [XmlAttribute(AttributeName = "previous_policy_number")]
            public string Previous_policy_number { get; set; }
        }
       
        [XmlRoot(ElementName = "transactions")]
        public class Transactions
        {
            [XmlElement(ElementName = "new_business")]
            public New_business New_business { get; set; }

            [XmlElement(ElementName = "renewal")]
            public Renewal Renewal { get; set; }

            [XmlElement(ElementName = "reissue")]
            public Reissue Reissue { get; set; }

            [XmlElement(ElementName = "reinstatement")]
            public Reinstatement Reinstatement { get; set; }

            [XmlElement(ElementName = "policy_cancellation")]
            public PolicyCancellation PolicyCancellation { get; set; }

            [XmlElement(ElementName = "endorsement")]
            public Endorsement Endorsement { get; set; }

        }

        [XmlRoot(ElementName = "redhawk_internal")]
        public class Redhawk_internal
        {
            [XmlElement(ElementName = "orig_tans_code")]
            public string Orig_tans_code { get; set; }
        }

        [XmlRoot(ElementName = "policy_transaction_group")]
        public class Policy_transaction_group
        {
            [XmlElement(ElementName = "transactions")]
            public Transactions Transactions { get; set; }
            [XmlElement(ElementName = "pi_use")]
            public string Pi_use { get; set; }
            [XmlElement(ElementName = "redhawk_internal")]
            public Redhawk_internal Redhawk_internal { get; set; }

            [Editable(false)]
            [XmlAttribute(AttributeName = "policy_number")]
            public string Policy_number { get; set; }
            [XmlAttribute(AttributeName = "policy_module")]
            public string Policy_module { get; set; }
        }

    }


}



