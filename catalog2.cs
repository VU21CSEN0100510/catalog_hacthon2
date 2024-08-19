using System;
using System.Collections.Generic;

class Crop
{
    public string Name { get; }
    public double IdealPH { get; }
    public string WaterRequirement { get; }
    public string SoilType { get; }

    public Crop(string name, double idealPH, string waterRequirement, string soilType)
    {
        Name = name;
        IdealPH = idealPH;
        WaterRequirement = waterRequirement;
        SoilType = soilType;
    }
}

class Soil
{
    public string SoilType { get; }
    public double PHLevel { get; }
    public string MoistureLevel { get; }

    public Soil(string soilType, double phLevel, string moistureLevel)
    {
        SoilType = soilType;
        PHLevel = phLevel;
        MoistureLevel = moistureLevel;
    }
}

class CropManagementSystem
{
    private List<Crop> Crops;

    public CropManagementSystem()
    {
        Crops = new List<Crop>
        {
            new Crop("Wheat", 6.0, "Moderate", "Loamy"),
            new Crop("Rice", 5.5, "High", "Clay"),
            new Crop("Maize", 6.5, "Moderate", "Sandy"),
            new Crop("Sugarcane", 6.0, "High", "Alluvial"),
            new Crop("Potato", 5.8, "Moderate", "Sandy Loam")
        };
    }

    public void RecommendCrop(Soil soil)
    {
        var recommendedCrops = new List<Crop>();
        foreach (var crop in Crops)
        {
            if (crop.SoilType == soil.SoilType && soil.PHLevel >= crop.IdealPH - 0.5 && soil.PHLevel <= crop.IdealPH + 0.5)
            {
                recommendedCrops.Add(crop);
            }
        }

        if (recommendedCrops.Count == 0)
        {
            Console.WriteLine("No suitable crops found for your soil conditions.");
        }
        else
        {
            Console.WriteLine("\nRecommended crops for your soil:");
            foreach (var crop in recommendedCrops)
            {
                Console.WriteLine($"Crop: {crop.Name}, Water Requirement: {crop.WaterRequirement}");
            }
        }
    }

    public void IdentifyDisease(List<string> symptoms)
    {
        var diseaseDB = new Dictionary<string, string>
        {
            { "yellow leaves", "Nitrogen Deficiency" },
            { "brown spots", "Potassium Deficiency" },
            { "wilting", "Drought Stress" },
            { "white powder", "Powdery Mildew" },
            { "root rot", "Fungal Infection" }
        };

        Console.WriteLine("\nDisease Identification:");
        foreach (var symptom in symptoms)
        {
            if (diseaseDB.ContainsKey(symptom.ToLower()))
            {
                Console.WriteLine($"Symptom: {symptom} - Possible Disease: {diseaseDB[symptom.ToLower()]}");
            }
            else
            {
                Console.WriteLine($"Symptom: {symptom} - No disease found in the database.");
            }
        }
    }

    public void ManageCrop()
    {
        Console.WriteLine("Crop Management System");
        Console.WriteLine("======================");
        Console.Write("Enter soil type (Loamy, Clay, Sandy, Alluvial, Sandy Loam): ");
        string soilType = Console.ReadLine();
        Console.Write("Enter soil pH level: ");
        double phLevel = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter moisture level (Low, Moderate, High): ");
        string moistureLevel = Console.ReadLine();

        Soil soil = new Soil(soilType, phLevel, moistureLevel);
        RecommendCrop(soil);

        Console.Write("\nDo you want to check for crop diseases? (yes/no): ");
        string checkDisease = Console.ReadLine();

        if (checkDisease.ToLower() == "yes")
        {
            Console.Write("Enter symptoms separated by commas (e.g., yellow leaves, brown spots): ");
            string[] symptomsArray = Console.ReadLine().Split(',');
            List<string> symptoms = new List<string>();
            foreach (var symptom in symptomsArray)
            {
                symptoms.Add(symptom.Trim());
            }
            IdentifyDisease(symptoms);
        }
    }
}

class Program
{
    static void Main()
    {
        CropManagementSystem cms = new CropManagementSystem();
        cms.ManageCrop();
    }
}
