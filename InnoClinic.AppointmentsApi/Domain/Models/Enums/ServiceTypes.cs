
namespace Domain.Models.Enums
{
    public enum ServiceTypes
    {
        // Pediatrics
        PediatricCheckup = 101,
        Vaccination,
        PediatricEmergency,

        // Cardiology
        CardiacConsultation = 201,
        Electrocardiogram,
        CardiacSurgery,

        // Dermatology
        SkinConsultation = 301,
        DermatologicalProcedure,
        LaserTherapy,

        // Neurology
        NeurologicalConsultation = 401,
        Electroencephalogram,
        Neurosurgery,

        // Ophthalmology
        EyeExam = 501,
        CataractSurgery,
        RetinalSpecialist,

        // Dentistry
        DentalCheckup = 601,
        ToothExtraction,
        Orthodontics,

        // Psychiatry
        MentalHealthConsultation = 701,
        Psychotherapy,
        AddictionTreatment,

        // Surgery
        GeneralSurgery = 801,
        OrthopedicSurgery,
        PlasticSurgery,

        // Nephrology
        KidneyConsultation = 901,
        Dialysis,
        KidneyTransplant
    }
}
