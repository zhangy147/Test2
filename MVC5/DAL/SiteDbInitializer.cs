using System;
using System.Collections.Generic;
using System.Data.Entity;
using MVC5.DatabaseContexts;
using MVC5.Models;

namespace MVC5.DAL
{
    public class SiteDbInitializer : DropCreateDatabaseIfModelChanges<SiteDbContext>
    {
        protected override void Seed(SiteDbContext context)
        {
            var BodyParts = new List<BodyPart>
            {
                new BodyPart { BodyPartID = 1, Name = "hair", Desc = "", CName = "头发", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 2, Name = "nape", Desc = "", CName = "颈部", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 3, Name = "head", Desc = "", CName = "头部", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 4, Name = "neck back", Desc = "", CName = "颈后面", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 5, Name = "shoulder blade", Desc = "", CName = "肩胛骨", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 6, Name = "arm", Desc = "", CName = "臂", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 7, Name = "elbow", Desc = "", CName = "肘", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 8, Name = "waist", Desc = "", CName = "腰部", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 9, Name = "trunk", Desc = "", CName = "躯干", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 10, Name = "face", Desc = "", CName = "脸", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 11, Name = "hip", Desc = "", CName = "臀部", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 12, Name = "forearm", Desc = "", CName = "前臂", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 13, Name = "wrist", Desc = "", CName = "手腕", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 14, Name = "hand", Desc = "", CName = "手", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 15, Name = "buttock", Desc = "", CName = "臀部", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 16, Name = "thigh", Desc = "", CName = "大腿", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 17, Name = "leg", Desc = "", CName = "腿", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 18, Name = "calf", Desc = "", CName = "小腿", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 19, Name = "foot bottom", Desc = "", CName = "脚底部", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 20, Name = "heel", Desc = "", CName = "脚跟", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 21, Name = "eye", Desc = "", CName = "眼睛", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 22, Name = "nose", Desc = "", CName = "鼻子", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 23, Name = "cheek", Desc = "", CName = "脸颊", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 24, Name = "chin", Desc = "", CName = "下巴", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 25, Name = "mouth", Desc = "", CName = "嘴", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 26, Name = "neck front", Desc = "", CName = "颈正面", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 27, Name = "shoulder front", Desc = "", CName = "肩正面", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 28, Name = "armpit", Desc = "", CName = "腋下", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 29, Name = "breast", Desc = "", CName = "乳房", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 30, Name = "chest back", Desc = "", CName = "后背", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 31, Name = "chest front", Desc = "", CName = "前胸", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 32, Name = "navel", Desc = "", CName = "肚脐", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 33, Name = "abdomen", Desc = "", CName = "腹部", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 34, Name = "pubis", Desc = "", CName = "耻骨", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 35, Name = "groin", Desc = "", CName = "腹股沟", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 36, Name = "knee", Desc = "", CName = "膝", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 37, Name = "foot above", Desc = "", CName = "脚正面", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 38, Name = "ankle", Desc = "", CName = "脚踝", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 39, Name = "toe", Desc = "", CName = "脚趾", CDesc = "", ImageLink = "" },
                //
                new BodyPart { BodyPartID = 40, Name = "Right upper abdomen", Desc = "", CName = "右上腹", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 41, Name = "Left upper abdomen", Desc = "", CName = "左上腹", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 42, Name = "Right lower abdomen", Desc = "", CName = "右下腹", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 43, Name = "Left lower upper abdomen", Desc = "", CName = "左下腹", CDesc = "", ImageLink = "" },
                //
                new BodyPart { BodyPartID = 44, Name = "Right chest", Desc = "", CName = "右胸", CDesc = "", ImageLink = "" },
                new BodyPart { BodyPartID = 45, Name = "Left chest", Desc = "", CName = "左胸", CDesc = "", ImageLink = "" },
                //
                new BodyPart { BodyPartID = 46, Name = "whole body", Desc = "", CName = "左胸", CDesc = "", ImageLink = "" },
            };
            BodyParts.ForEach(s => context.BodyParts.Add(s));
            context.SaveChanges();

            //Gastrointentinal, Cardiovascular, Respiratory, Urinary, Obstetric, Gynecological, Endocrine, Dermatolory, Other
            var BodySystems = new List<BodySystem>
            {
                new BodySystem { BodySystemID = 1, Name = "Respiratory system", CName = "呼吸系统",
                    Desc = "The lungs and the trachea that bring air into the body.", 
                    CDesc="通过肺和气管将空气吸入人体内。", ImageLink = "" },
                new BodySystem { BodySystemID = 2, Name = "Cardiovascular system", CName = "心血管系统",
                    Desc = "Circulates blood around the body via the heart, arteries and veins, delivering oxygen and nutrients to organs and cells and carrying their waste products away.", 
                    CDesc = "驱动身体周围的血液通过心脏，动脉和静脉，提供器官和细胞需要的氧气和营养，并将器官和细胞产生的废物携带出体外。", ImageLink = "" },
                new BodySystem { BodySystemID = 3, Name = "Digestive system", CName = "消化系统",
                    Desc = "Mechanical and chemical processes that provide nutrients via the mouth, esophagus, stomach and intestines.", 
                    CDesc = "使用机械和化学过程,由口腔，食道，胃和肠为人体提供营养物质。", ImageLink = "" },
                new BodySystem { BodySystemID = 4, Name = "Urinary system", CName = "泌尿系统",
                    Desc = "Part of the excretory system.", 
                    CDesc="将身体废物以尿液的形式排出体外", ImageLink = "" },
                new BodySystem { BodySystemID = 5, Name = "Reproductive system", CName = "生殖系统",
                    Desc = "The sex organs required for the production of offspring.", 
                    CDesc ="生产后代的性器官。", ImageLink = "" },
                new BodySystem { BodySystemID = 6, Name = "Endocrine", CName = "内分泌系统",
                    Desc = "Provides chemical communications within the body using hormones.", 
                    CDesc = "通过激素提供体内的化学通讯", ImageLink = "" },
                new BodySystem { BodySystemID = 7, Name = "Excretory system", CName = "排泄系统",
                    Desc = "Eliminates waste from the body.", 
                    CDesc= "将身体废物排出体外", ImageLink = "" },
                new BodySystem { BodySystemID = 8, Name = "Lymphatic system", CName = "淋巴系统",
                    Desc = "Supplies and drains lymph fluid in support of the cardiovascular and immune systems.", 
                    CDesc = "通过传导淋巴液来支持心血管和免疫系统。", ImageLink = "" },
                new BodySystem { BodySystemID = 9, Name = "Immmune system", CName = "免疫系统",
                    Desc = "Defends the body against disease-causing agents.", 
                    CDesc = "保卫机体免受致病因子的侵袭", ImageLink = "" },
                new BodySystem { BodySystemID = 10, Name = "Nervous system", CName = "神经系统",
                    Desc = "Collects and processes information from the senses via nerves and the brain and tells the muscles to contract to cause physical actions.", 
                    CDesc = "通过神经和大脑收集和处理来自感官的信息，并通过肌肉收缩形成肢体动作。", ImageLink = "" },
                new BodySystem { BodySystemID = 11, Name = "Integumentary system", CName = "外皮系统",
                    Desc = "Skin, hair, nails, sweat and other exocrine glands.", 
                    CDesc = "包括皮肤，头发，指甲，汗液等外分泌腺。", ImageLink = "" },
                new BodySystem { BodySystemID = 12, Name = "Muscular system", CName = "肌肉系统",
                    Desc = "Enables the body to move using muscles.", 
                    CDesc = "通过肌肉使身体运动", ImageLink = "" },
                new BodySystem { BodySystemID = 13, Name = "Skeletal system", CName = "骨骼系统", 
                    Desc = "Bones supporting the body and its organs.", 
                    CDesc = "使用骨骼支撑身体和器官", ImageLink = "" },
                new BodySystem { BodySystemID = 14, Name = "General", CName = "全身系统", 
                    Desc = "All systems of human body", 
                    CDesc = "全身系统", ImageLink = "" },
                 new BodySystem { BodySystemID = 15, Name = "Eyes", CName = "眼睛", 
                    Desc = "Eyes", 
                    CDesc = "眼睛", ImageLink = "" },
                 new BodySystem { BodySystemID = 16, Name = "Ear,Nose,Throat,Mouth", CName = "耳，鼻，喉，口腔", 
                    Desc = "Ear,Nose,Throat,Mouth", 
                    CDesc = "耳，鼻，喉，口腔", ImageLink = "" },
                 new BodySystem { BodySystemID = 17, Name = "Breast", CName = "乳房", 
                    Desc = "Breast", 
                    CDesc = "乳房", ImageLink = "" }
            };
            BodySystems.ForEach(s => context.BodySystems.Add(s));
            context.SaveChanges();

            //
            var Diseases = new List<Disease>
            {
                new Disease {
                     DiseaseID = 11, 
                     Name = "Primary Hypertension",
                     CName = "原发性高血压",
                     Abbreviation = "PH",
                     BodySystemID = 2,
                     UsedForPMH = true,
                     UsedForFMH = true,
                     MedicalRecords = new List<MedicalRecord>() 
                },
                new Disease {
                    DiseaseID = 12,
                    Name = "Diabetes",
                    CName = "糖尿病",
                    Abbreviation = "DB",
                    BodySystemID = 6,
                    UsedForPMH = true,
                    UsedForFMH = true,
                    MedicalRecords = new List<MedicalRecord>() 
                },
                new Disease {
                    DiseaseID = 13,
                    Name = "Ruptured Aortic Aneurysm",
                    CName = "主动脉瘤破裂",
                    Abbreviation = "RAA",
                    BodySystemID = 2,
                    UsedForPMH = false,
                    UsedForFMH = false,
                    MedicalRecords = new List<MedicalRecord>() 
                },
                new Disease {
                    DiseaseID = 14,
                    Name = "Acute Appendicitis",
                    CName = "急性阑尾炎",
                    Abbreviation = "AA",
                    BodySystemID = 3,
                    UsedForPMH = false,
                    UsedForFMH = false,
                    MedicalRecords = new List<MedicalRecord>() 
                },
                new Disease {
                    DiseaseID = 15,
                    Name = "Diverticulitis",
                    CName = "结肠憩室炎",
                    Abbreviation = "DV",
                    BodySystemID = 3,
                    UsedForPMH = true,
                    UsedForFMH = false,
                    MedicalRecords = new List<MedicalRecord>() 
                },
                new Disease {
                    DiseaseID = 16,
                    Name = "Gastroenteritis",
                    CName = "胃肠炎",
                    Abbreviation = "GA",
                    BodySystemID = 3,
                    UsedForPMH = false,
                    UsedForFMH = false,
                    MedicalRecords = new List<MedicalRecord>() 
                },
                new Disease {
                    DiseaseID = 17,
                    Name = "Inflammatory Bowel Disease",
                    CName = "炎症性肠病",
                    Abbreviation = "IBD",
                    BodySystemID = 3,
                    UsedForPMH = true,
                    UsedForFMH = true,
                    MedicalRecords = new List<MedicalRecord>() 
                },
                new Disease {
                    DiseaseID = 18,
                    Name = "Intestinal Obstruction",
                    CName = "肠梗阻",
                    Abbreviation = "IO",
                    BodySystemID = 3,
                    UsedForPMH = false,
                    UsedForFMH = false,
                    MedicalRecords = new List<MedicalRecord>() 
                },
                new Disease {
                    DiseaseID = 19,
                    Name = "Pancreatitis",
                    CName = "胰腺炎",
                    Abbreviation = "PAN",
                    BodySystemID = 3,
                    UsedForPMH = true,
                    UsedForFMH = true,
                    MedicalRecords = new List<MedicalRecord>() 
                },
                new Disease {
                    DiseaseID = 20,
                    Name = "Peptic Ulcer Disease",
                    CName = "消化性溃疡",
                    Abbreviation = "PUD",
                    BodySystemID = 3,
                    UsedForPMH = true,
                    UsedForFMH = true,
                    MedicalRecords = new List<MedicalRecord>() 
                },
                new Disease {
                    DiseaseID = 21,
                    Name = "Pelvic Inflammatory Disease",
                    CName = "盆腔炎",
                    Abbreviation = "PID",
                    BodySystemID = 5,
                    UsedForPMH = true,
                    UsedForFMH = false,
                    MedicalRecords = new List<MedicalRecord>() 
                },
                new Disease {
                    DiseaseID = 22,
                    Name = "Testicular Torsion",
                    CName = "睾丸扭转",
                    Abbreviation = "TT",
                    BodySystemID = 5,
                    UsedForPMH = false,
                    UsedForFMH = false,
                    MedicalRecords = new List<MedicalRecord>() 
                },
                new Disease {
                    DiseaseID = 23,
                    Name = "Nephrolithiasis",
                    CName = "肾结石",
                    Abbreviation = "NEP",
                    BodySystemID = 4,
                    UsedForPMH = true,
                    UsedForFMH = false,
                    MedicalRecords = new List<MedicalRecord>() 
                }
            };
            Diseases.ForEach(s => context.Diseases.Add(s));
            context.SaveChanges();

            var Cancers = new List<Cancer>
            {
                new Cancer { DiseaseID = 3, Name = "Colon Cancer", Abbreviation = "Colon Cancer", Desc = "", 
                    CName = "结肠癌", Category = "Cancer",  BodySystemID = 3, 
                    MedicalRecords = new List<MedicalRecord>() 
                },
                new Cancer { DiseaseID = 4, Name = "Non-Small Cell Lung Cancer", Abbreviation = "NSCLC", Desc = "", 
                    CName = "非小细胞肺癌", Category = "Cancer", BodySystemID = 1, 
                    MedicalRecords = new List<MedicalRecord>()  
                },
                new Cancer { DiseaseID = 5, Name = "Gastric Cancer", Abbreviation = "Gastric Cancer", Desc = "", 
                    CName = "胃癌", Category = "Cancer", BodySystemID = 3, 
                    MedicalRecords = new List<MedicalRecord>() 
                },
                new Cancer { DiseaseID = 6, Name = "Breast Cancer", Abbreviation = "Breast Cancer", Desc = "", 
                    CName = "乳腺癌", Category = "Cancer", BodySystemID = 5, 
                    MedicalRecords = new List<MedicalRecord>() 
                },
                new Cancer { DiseaseID = 7, Name = "Pancrea Cancer", Abbreviation = "Pancrea Cancer", Desc = "", 
                    CName = "胰腺癌", Category = "Cancer", BodySystemID = 3, 
                    MedicalRecords = new List<MedicalRecord>() 
                },
                new Cancer { DiseaseID = 8, Name = "Hepatic Cancer", Abbreviation = "Heptical Cancer", Desc = "", 
                    CName = "肝癌", Category = "Cancer", BodySystemID = 3, 
                    MedicalRecords = new List<MedicalRecord>() 
                },
                new Cancer { DiseaseID = 9, Name = "Leukemia", Abbreviation = "Leukemia", Desc = "", 
                    CName = "白血病", Category = "Cancer", BodySystemID = 3, 
                    MedicalRecords = new List<MedicalRecord>() 
                },
                new Cancer { DiseaseID = 10, Name = "Non-Hodgkin Lymphoma", Abbreviation = "Non-Hodgkin Lymphoma", Desc = "", 
                    CName = "非霍奇金淋巴瘤", Category = "Cancer", BodySystemID = 3, 
                    MedicalRecords = new List<MedicalRecord>() 
                }

            };
            Cancers.ForEach(c => context.Cancers.Add(c));
            context.SaveChanges();

            var ConsultingServices = new List<ConsultingService>
            {
                new ConsultingService { 
                    ServiceID = 1, ServiceName = "Expert Second Opinion", ServiceName_ZH = "医疗第二意见", 
                    ServiceDesc = "", 
                    ServiceDesc_ZH = "",
                    AllowChooseProvider = true
                },
                new ConsultingService { 
                    ServiceID = 2, ServiceName = "Live Online Consulting", ServiceName_ZH = "在线医疗咨询", 
                    ServiceDesc = "", 
                    ServiceDesc_ZH = "",
                    AllowChooseProvider = false
                },
                new ConsultingService { 
                    ServiceID = 3, ServiceName = "Best Treatment Report", ServiceName_ZH = "最佳疗法报告", 
                    ServiceDesc = "", 
                    ServiceDesc_ZH = "",
                    AllowChooseProvider = false
                },
                new ConsultingService { 
                    ServiceID = 4, ServiceName = "Obtain Treatment In USA", ServiceName_ZH = "来美就医服务", 
                    ServiceDesc = "", 
                    ServiceDesc_ZH = "",
                    AllowChooseProvider = false
                }
            };
            ConsultingServices.ForEach(s => context.ConsultingServices.Add(s));
            context.SaveChanges();
            //

            var ServiceProviders = new List<ServiceProvider>
            { 
                new ServiceProvider {
                    ProviderID = 1, 
                    ProviderName = "Cleveland Clinic", 
                    ProviderName_ZH = "克利夫兰诊所",
                    ConsultingServices = new List<ConsultingService>()
                },
                new ServiceProvider {
                    ProviderID = 2, 
                    ProviderName = "OSU Wexner Medical Center", 
                    ProviderName_ZH = "俄亥俄州立大学Wexner医学中心",
                    ConsultingServices = new List<ConsultingService>()
                },
                new ServiceProvider {
                    ProviderID = 3, 
                    ProviderName = "Our Contracted Specialists", 
                    ProviderName_ZH = "公司特约医学专家",
                    ConsultingServices = new List<ConsultingService>()
                }
            };
            ServiceProviders.ForEach(s => context.ServiceProviders.Add(s));
            context.SaveChanges();
            //
            ServiceProviders[0].ConsultingServices.Add(ConsultingServices[0]);
            ServiceProviders[1].ConsultingServices.Add(ConsultingServices[0]);
            ServiceProviders[2].ConsultingServices.Add(ConsultingServices[0]);
            ServiceProviders[2].ConsultingServices.Add(ConsultingServices[1]);
            ServiceProviders[2].ConsultingServices.Add(ConsultingServices[2]);
            ServiceProviders[2].ConsultingServices.Add(ConsultingServices[3]);
            context.SaveChanges();
            //

            //
            var PatientProfiles = new List<PatientProfile>
            {
                new PatientProfile { 
                    PatientProfileID = 1,  
                    UserID = 100, 
                    Age = 62, 
                    Gender = Gender.Female, 
                    Ethnic = EthnicGroup.Asian,
                    DiseaseID = 14, 
                    DateDiagnosed = DateTime.Parse("2012-05-06"), 
                    HospitalDiagnosisMade = "MCO Medical Center",
                    Concerns = "Is the current treatment the most effective one",
                    Goals = "",
                    //RequestedServices = new List<RequestedService>(),
                    //PatientQuestions = new List<PatientQuestion>(),
                    //SuggestedReadingLinks = new List<SuggestedReadingLink>(),
                    //PhysicianNotes = new List<PhysicianNote>(),
                    //
                    
                    InsertDate = DateTime.Parse("2013-12-21"), 
                    UpdateDate = DateTime.Parse("2014-04-21")
                },
                new PatientProfile { 
                    PatientProfileID = 2,  
                    UserID = 100, 
                    Age = 71, 
                    Gender = Gender.Male, 
                    Ethnic =  EthnicGroup.Asian,
                    DiseaseID = 4, 
                    DateDiagnosed = DateTime.Parse("2011-08-06"), 
                    HospitalDiagnosisMade = "Beijing Fouth District Hospital",
                    Concerns = "Complicated with low blood cell, should the does be reduced?",
                    Goals = "",
                    //RequestedServices = new List<RequestedService>(),
                    //PatientQuestions = new List<PatientQuestion>(),
                    //SuggestedReadingLinks = new List<SuggestedReadingLink>(),
                    //PhysicianNotes = new List<PhysicianNote>(),
                    //
                    
                    InsertDate = DateTime.Parse("2011-09-01"), 
                    UpdateDate = DateTime.Parse("2013-04-21") }
            };
            PatientProfiles.ForEach(s => context.PatientProfiles.Add(s));
            context.SaveChanges();

            //PatientProfiles[0].ProceduresDone.Add(Procedures[0]);
            //PatientProfiles[0].ProceduresDone.Add(Procedures[0]);
            //PatientProfiles[0].ProceduresDone.Add(Procedures[1]);
            //PatientProfiles[0].ProceduresDone.Add(Procedures[3]);
            //PatientProfiles[0].ProceduresDone.Add(Procedures[4]);
            //PatientProfiles[0].ProceduresDone.Add(Procedures[5]);
            //PatientProfiles[0].ProceduresDone.Add(Procedures[6]);
            //PatientProfiles[0].ProceduresDone.Add(Procedures[8]);
            //PatientProfiles[0].ProceduresDone.Add(Procedures[9]);
            //PatientProfiles[0].ProceduresDone.Add(Procedures[10]);
            //PatientProfiles[0].ProceduresDone.Add(Procedures[13]);
            //PatientProfiles[0].ProceduresDone.Add(Procedures[14]);
            //PatientProfiles[1].ProceduresDone.Add(Procedures[0]);
            //PatientProfiles[1].ProceduresDone.Add(Procedures[1]);
            //PatientProfiles[1].ProceduresDone.Add(Procedures[2]);
            //PatientProfiles[1].ProceduresDone.Add(Procedures[5]);
            //PatientProfiles[1].ProceduresDone.Add(Procedures[6]);
            //PatientProfiles[1].ProceduresDone.Add(Procedures[7]);
            //PatientProfiles[1].ProceduresDone.Add(Procedures[8]);
            //context.SaveChanges();

            //patient 1
            //PatientProfiles[0].TreatmentIndications.Add(TreatmentIndications[0]);
            //PatientProfiles[0].TreatmentIndications.Add(TreatmentIndications[2]);
            //PatientProfiles[0].TreatmentIndications.Add(TreatmentIndications[5]);
            //PatientProfiles[0].TreatmentIndications.Add(TreatmentIndications[6]);
            ////
            ////patient 2
            //PatientProfiles[1].TreatmentIndications.Add(TreatmentIndications[27]);
            //PatientProfiles[1].TreatmentIndications.Add(TreatmentIndications[25]);
            ////PatientProfiles[1].TreatmentIndications.Add(TreatmentIndications[5]);
            ////PatientProfiles[1].TreatmentIndications.Add(TreatmentIndications[7]);
            ////PatientProfiles[1].TreatmentIndications.Add(TreatmentIndications[10]);
            ////context.SaveChanges();
            //
            var RequestedServices = new List<RequestedService>()
            {
                new RequestedService {
                    RequestedServiceID = 1,
                    ServiceID = 1,
                    ProviderID = 3,
                    PatientProfileID = 1,
                    InsertDate = DateTime.Parse("2015-02-21"), 
                },
                new RequestedService {
                    RequestedServiceID = 2,
                    ServiceID = 3,
                    ProviderID = 3,
                    PatientProfileID = 1,
                    InsertDate = DateTime.Parse("2015-02-21"), 
                }

            };
            RequestedServices.ForEach(s => context.RequestedServices.Add(s));
            context.SaveChanges();


            var Physicians = new List<Physician>()
            {
                new Physician {
                    PhysicianID = 1,
                    Specialty = "Oncologist",
                    MedicalSchool = "Medical College of Ohio",
                    ResidenceTraining = "Harvard Medical Center in Boston from 2000 to 2006.",
                    GraduationYear = 1998,
                    GroupAffiliation = "OSU Medical Center"
                },
                new Physician {
                    PhysicianID = 2,
                    Specialty = "Cardiologist",
                    MedicalSchool = "Beijing University Medical School",
                    GraduationYear = 1981,
                    ResidenceTraining = "Cleveland Clicnis from 2003 to 2007.",
                    GroupAffiliation = "Buckeye Health Group"
                },
                new Physician {
                    PhysicianID = 3,
                    Specialty = "Oncologist",
                    MedicalSchool = "OSU Medical Center",
                    GraduationYear = 2000,
                    ResidenceTraining = "Cincinnati University Hospital and University Michigan from 2004 to 2008.",
                    GroupAffiliation = "OSU Medical Center"
                },
            };
            Physicians.ForEach(s => context.Physicians.Add(s));
            context.SaveChanges();

            //
            var PatientQuestions = new List<PatientQuestion>() 
            {
                new PatientQuestion {
                    PatientQuestionID = 1,
                    PatientProfileID = 1,
                    QuestionAsked = "Should I try herbs treatment during chemotherapy?",
                    DateAsked = DateTime.Parse("2015-03-04"), 
                    Answer = "Herbs may increase or decrese the enzyme activities in your liver, these effects may reduce or enhance the effects and toxicities of chemotherapy. So refraining from herbs during active chemothaepy is better.",
                    DateAnswered = DateTime.Parse("2015-03-05"), 
                    PhysicianID = 1
                },
                new PatientQuestion {
                    PatientQuestionID = 2,
                    PatientProfileID = 1,
                    QuestionAsked = "When should I stop chemotherapy?",
                    DateAsked = DateTime.Parse("2015-03-06"), 
                    Answer = "The firstline chemotherapy shoul continue 6 months before deciding to continue, discontinue or change to other treatment.",
                    DateAnswered = DateTime.Parse("2015-03-15"), 
                    PhysicianID = 3
                }
            };
            PatientQuestions.ForEach(s => context.PatientQuestions.Add(s));
            context.SaveChanges();
            //
            //MedicalRecord
            var MedicalRecords = new List<MedicalRecord>()
            {
                new MedicalRecord {
                    MedicalRecordID = 1,
                    Name = "Physician current report",
                    Type = "",
                    Desc = "The report should contain current physician assessment of teh patient's condition, description of current signs and symptoms, and tretament recommendations, This can be written by either your primary care physician or the physician who diagnosed or is treating your condition",
                    IsMandatory = true,
                },
                new MedicalRecord {
                    MedicalRecordID = 2,
                    Name = "Notation of medications",
                    Type = "",
                    Desc = "Listing of all medications prescribed by doctor, including prescription, over teh counter, vitamin, supplement and herb product",
                    IsMandatory = true,
                },
                new MedicalRecord {
                    MedicalRecordID = 3,
                    Name = "Report from pathologist",
                    Type = "",
                    Desc = "Report and glass slides from pathologist or department of pathology about all body samples or biopsies.",
                    IsMandatory = true,
                },
                new MedicalRecord {
                    MedicalRecordID = 4,
                    Name = "Surgical report",
                    Type = "",
                    Desc = "Report created by surgeons after surgery relevent to patient current situation.",
                    IsMandatory = true,
                },
                new MedicalRecord {
                    MedicalRecordID = 5,
                    Name = "Physician treatment plan",
                    Type = "",
                    Desc = "All treatment plans for current diagnosis including chemptherapy, radiation therapy, etc. The plan should document medication, dosage, schedule, treatment duration.",
                    IsMandatory = true,
                },
                new MedicalRecord {
                    MedicalRecordID = 6,
                    Name = "Discharge summary",
                    Type = "",
                    Desc = "Discharge summary from any recent (within one year) hospitalization(s).",
                    IsMandatory = true,
                },
                new MedicalRecord {
                    MedicalRecordID = 7,
                    Name = "Current blood work",
                    Type = "",
                    Desc = "Blood test report relevant to patient current disease within past 6 months",
                    IsMandatory = true,
                },
                new MedicalRecord {
                    MedicalRecordID = 8,
                    Name = "Chest X-ray, PA and lateral views",
                    Type = "",
                    Desc = "Diagnostic or pre-treatment evaluation procedure report relevant to patient current disease",
                    IsMandatory = false,
                },
                new MedicalRecord {
                    MedicalRecordID = 9,
                    Name = "Brain MRI",
                    Type = "",
                    Desc = "Diagnostic or pre-treatment evaluation procedure report",
                    IsMandatory = false,
                }
            };
            MedicalRecords.ForEach(s => context.MedicalRecords.Add(s));
            context.SaveChanges();
            //
            //Disease[0] = primary hypertension
            Diseases[0].MedicalRecords.Add(MedicalRecords[0]);
            Diseases[0].MedicalRecords.Add(MedicalRecords[1]);
            Diseases[0].MedicalRecords.Add(MedicalRecords[2]);
            Diseases[0].MedicalRecords.Add(MedicalRecords[3]);
            Diseases[0].MedicalRecords.Add(MedicalRecords[4]);
            Diseases[0].MedicalRecords.Add(MedicalRecords[5]);
            Diseases[0].MedicalRecords.Add(MedicalRecords[6]);
            Diseases[0].MedicalRecords.Add(MedicalRecords[7]);
            Diseases[0].MedicalRecords.Add(MedicalRecords[8]);
            context.SaveChanges();
            //
            //Cancer[0] = colon cancer
            Cancers[0].MedicalRecords.Add(MedicalRecords[0]);
            Cancers[0].MedicalRecords.Add(MedicalRecords[1]);
            Cancers[0].MedicalRecords.Add(MedicalRecords[2]);
            Cancers[0].MedicalRecords.Add(MedicalRecords[3]);
            Cancers[0].MedicalRecords.Add(MedicalRecords[4]);
            Cancers[0].MedicalRecords.Add(MedicalRecords[5]);
            Cancers[0].MedicalRecords.Add(MedicalRecords[6]);
            Cancers[0].MedicalRecords.Add(MedicalRecords[7]);
            Cancers[0].MedicalRecords.Add(MedicalRecords[8]);
            context.SaveChanges();
            //
            //
            var PatientMedicalHistories = new List<PatientMedicalHistory>() {
                new PatientMedicalHistory {
                    PatientMedicalHistoryID = 1,
                    PatientProfileID = 1,
                    DiseaseID = 1,
                    IsPositive = true,
                    PatientSuppliedCondition = "",
                    PatientNote = ""
                },
                new PatientMedicalHistory {
                    PatientMedicalHistoryID = 2,
                    PatientProfileID = 1,
                    DiseaseID = 13,
                    IsPositive = true,
                    PatientSuppliedCondition = "",
                    PatientNote = ""
                }
            };
            PatientMedicalHistories.ForEach(s => context.PatientMedicalHistories.Add(s));
            context.SaveChanges();
            //
            var PatientSurgicalHistories = new List<PatientSurgicalHistory>() {
                new PatientSurgicalHistory {
                    PatientSurgicalHistoryID = 1,
                    PatientProfileID = 1,
                    TreatmentID = 42,
                    PatientReplied = true,
                    DatePerformed = DateTime.Parse("2008-2-16"),
                    PatientSuppliedCondition = "",
                    PatientNote = ""
                },
                new PatientSurgicalHistory {
                    PatientSurgicalHistoryID = 2,
                    PatientProfileID = 1,
                    TreatmentID = 13,
                    PatientReplied = true,
                    DatePerformed = DateTime.Parse("2011-12-6"),
                    PatientSuppliedCondition = "",
                    PatientNote = ""
                },
            };
            PatientSurgicalHistories.ForEach(s => context.PatientSurgicalHistories.Add(s));
            context.SaveChanges();
            //
            //var DiagnosticFactors = new List<DiagnosticFactor>
            //{
            //    //system id=14
            //    new DiagnosticFactor { 
            //        DiagnosticFactorID = 1, 
            //        Name = "Fever", 
            //        Desc = "Faver",
            //        CName = "发烧",
            //        CDesc = "发烧",
            //        Type = DiagnosticFactorType.Symptom,
            //        BodySystemID = 14
            //    },
            //    new DiagnosticFactor { 
            //        DiagnosticFactorID = 2, 
            //        Name = "Chills", 
            //        Desc = "Chills",
            //        CName = "畏寒",
            //        CDesc = "畏寒",
            //        Type = DiagnosticFactorType.Symptom,
            //        BodySystemID = 14
            //    },
            //    new DiagnosticFactor { 
            //        DiagnosticFactorID = 3, 
            //        Name = "Weight loss", 
            //        Desc = "Weight loss",
            //        CName = "体重",
            //        CDesc = "体重",
            //        Type = DiagnosticFactorType.Symptom,
            //        BodySystemID = 14
            //    },
            //    new DiagnosticFactor { 
            //        DiagnosticFactorID = 4, 
            //        Name = "Headache", 
            //        Desc = "Headache",
            //        CName = "头痛",
            //        CDesc = "头痛",
            //        Type = DiagnosticFactorType.Symptom,
            //        BodySystemID = 14
            //    },
            //    //Eyes = 15
            //    new DiagnosticFactor { 
            //        DiagnosticFactorID = 5, 
            //        Name = "Blurred vision", 
            //        Desc = "Blurred vision",
            //        CName = "视力模糊",
            //        CDesc = "视力模糊",
            //        Type = DiagnosticFactorType.Symptom,
            //        BodySystemID = 15
            //    },
            //    new DiagnosticFactor { 
            //        DiagnosticFactorID = 6, 
            //        Name = "Double vision", 
            //        Desc = "Double vision",
            //        CName = "双瞳",
            //        CDesc = "双瞳",
            //        Type = DiagnosticFactorType.Symptom,
            //        BodySystemID = 15
            //    },
            //    new DiagnosticFactor { 
            //        DiagnosticFactorID = 7, 
            //        Name = "Vision changes", 
            //        Desc = "Vision changes",
            //        CName = "视力变化",
            //        CDesc = "视力变化",
            //        Type = DiagnosticFactorType.Symptom,
            //        BodySystemID = 15
            //    },
            //    //Cardiovascular = 2
            //    new DiagnosticFactor { 
            //        DiagnosticFactorID = 8, 
            //        Name = "Chest pain", 
            //        Desc = "Chest pain",
            //        CName = "胸痛",
            //        CDesc = "胸痛",
            //        Type = DiagnosticFactorType.Symptom,
            //        BodySystemID = 2
            //    },
            //    new DiagnosticFactor { 
            //        DiagnosticFactorID = 9, 
            //        Name = "Difficulty breathing", 
            //        Desc = "Difficulty breathing",
            //        CName = "呼吸困难",
            //        CDesc = "呼吸困难",
            //        Type = DiagnosticFactorType.Symptom,
            //        BodySystemID = 2
            //    },

            //    new DiagnosticFactor { 
            //        DiagnosticFactorID = 10, 
            //        Name = "Swelling", 
            //        Desc = "Swelling",
            //        CName = "肿胀",
            //        CDesc = "肿胀",
            //        Type = DiagnosticFactorType.Symptom,
            //        BodySystemID = 2
            //    },

            //    new DiagnosticFactor { 
            //        DiagnosticFactorID = 11, 
            //        Name = "Palpitation", 
            //        Desc = "Palpitation",
            //        CName = "心慌",
            //        CDesc = "心慌",
            //        Type = DiagnosticFactorType.Symptom,
            //        BodySystemID = 2
            //    },
            //    //Digestive = 3
            //    new DiagnosticFactor { 
            //        DiagnosticFactorID = 12, 
            //        Name = "Nausea/vomiting", 
            //        Desc = "Nausea/vomitingn",
            //        CName = "恶心/呕吐",
            //        CDesc = "恶心/呕吐",
            //        Type = DiagnosticFactorType.Symptom,
            //        BodySystemID = 3
            //    },
            //    new DiagnosticFactor { 
            //        DiagnosticFactorID = 13, 
            //        Name = "Constipation", 
            //        Desc = "Constipation",
            //        CName = "便秘",
            //        CDesc = "便秘",
            //        Type = DiagnosticFactorType.Symptom,
            //        BodySystemID = 3
            //    },
            //    new DiagnosticFactor { 
            //        DiagnosticFactorID = 14, 
            //        Name = "Diarrhea", 
            //        Desc = "Diarrhea",
            //        CName = "腹泻",
            //        CDesc = "腹泻",
            //        Type = DiagnosticFactorType.Symptom,
            //        BodySystemID = 3
            //    },
            //    new DiagnosticFactor { 
            //        DiagnosticFactorID = 15, 
            //        Name = "Abdominal pain", 
            //        Desc = "Abdominal pain",
            //        CName = "腹痛",
            //        CDesc = "腹痛",
            //        Type = DiagnosticFactorType.Symptom,
            //        BodySystemID = 3
            //    },
            //};
            //DiagnosticFactors.ForEach(s => context.DiagnosticFactors.Add(s));
            //context.SaveChanges();
            //
            //
            var PatientSystemReviews = new List<PatientSystemReview>() {
                new PatientSystemReview {
                    PatientSystemReviewID = 1,
                    PatientProfileID = 1,
                    DiagnosticFactorID = 1,
                    PatientReplied = true,
                    PatientSuppliedCondition = "",
                },
                new PatientSystemReview {
                    PatientSystemReviewID = 2,
                    PatientProfileID = 1,
                    DiagnosticFactorID = 7,
                    PatientReplied = false,
                    PatientSuppliedCondition = "",
                }
            };
            PatientSurgicalHistories.ForEach(s => context.PatientSurgicalHistories.Add(s));
            context.SaveChanges();
            //
            var PatientMedicalRecords = new List<PatientMedicalRecord>(){
                new PatientMedicalRecord {
                    PatientMedicalRecordID = 1,
                    PatientProfileID = 1, 
                    MedicalRecordID = 9,
                    DatePerformed = DateTime.Parse("2006-02-16"),
                    HospitalPerformed = "Columbus Grand Hospital",
                    UserNotes = "Doctor wanted to confirm if blood vessels in the brain had been plugged",
                    FileName = "mri_example.jpg",
                    FileType = "jpg",
                    FileLocation = "App_Data/uploads/Originals",
                    IsUploadedByUser = true,
                    UploadDate = DateTime.Parse("2014-04-16"),
                    InternalCode = ""
                }
            };
            PatientMedicalRecords.ForEach(s => context.PatientMedicalRecords.Add(s));
            context.SaveChanges();
            //
            var PatientFamilyMedicalHistories = new List<PatientFamilyMedicalHistory>()
            {
                new PatientFamilyMedicalHistory {
                    PatientFamilyMedicalHistoryID = 1,
                    PatientProfileID = 1,
                    DiseaseID = 1,
                    FamilyMember = FamilyMember.Father,
                    PatientNote = ""
                },
                new PatientFamilyMedicalHistory {
                    PatientFamilyMedicalHistoryID = 1,
                    PatientProfileID = 1,
                    DiseaseID = 2,
                    FamilyMember = FamilyMember.Father,
                    PatientNote = ""
                },
                new PatientFamilyMedicalHistory {
                    PatientFamilyMedicalHistoryID = 3,
                    PatientProfileID = 1,
                    DiseaseID = 1,
                    FamilyMember = FamilyMember.Grandparents,
                    PatientNote = ""
                }
            };
            PatientFamilyMedicalHistories.ForEach(s => context.PatientFamilyMedicalHistories.Add(s));
            context.SaveChanges();
            //
            var SubstanceUses = new List<SubstanceUse>()
            {
                new SubstanceUse {
                    SubstanceUseID = 10,
                    Type = SubstanceType.Tabacco,
                    Name = "",
                    IsCurrentInUse = true,
                    Quantity = "half pack a day",
                    LengthInYear = 15,
                    StoppedInYear = 0,
                }

            };
            SubstanceUses.ForEach(s => context.SubstanceUses.Add(s));
            context.SaveChanges();
            //
            var PatientSocialHistories = new List<PatientSocialHistory>()
            {
                new PatientSocialHistory {
                    PatientSocialHistoryID = 100,
                    PatientProfileID = 1,
                    SubstanceUses = new List<SubstanceUse>(),
                    MaritalStatus = MaritalStatus.Married,
                    EmploymentStatus = EmploymentStatus.Retired,
                    ExerciseLevel = ExerciseLevel.Sedentary,
                    CurrentJob = "",
                    WasMentallyAbused = false,
                    WasPhysicallyAbused  = false,
                    IsDisabled = false
                }
            };
            PatientSocialHistories.ForEach(s => context.PatientSocialHistories.Add(s));
            context.SaveChanges();

            PatientSocialHistories[0].SubstanceUses.Add(SubstanceUses[0]);
            context.SaveChanges();
            //
            //
            var Antigens = new List<Antigen>()
            {
                new Antigen {
                    AntigenID = 1,
                    Name = "Food",
                    Desc = "Egg etc."
                },
                new Antigen {
                    AntigenID = 2,
                    Name = "Grass",
                    Desc = "More severe in spring"
                },
                new Antigen{
                    AntigenID = 3,
                    Name = "Animal",
                    Desc = "allergy when playing with my cat"
                }
            };
            Antigens.ForEach(s => context.Antigens.Add(s));
            context.SaveChanges();
            //
            var AllergyReactions = new List<AllergyReaction>()
            {
                new AllergyReaction {
                    AllergyReactionID = 1,
                    AntigenID = 1,
                    Reaction = "sneesing and caugh",
                    IsPatientDescribed = true
                },
                new AllergyReaction {
                    AllergyReactionID = 2,
                    AntigenID = 3,
                    Reaction = "skin becomes red and swelling",
                    IsPatientDescribed = true,
                }
            };
            AllergyReactions.ForEach(s => context.AllergyReactions.Add(s));
            context.SaveChanges();
            //
            //
            var PatientAllergyHistories = new List<PatientAllergyHistory>()
            {
                new PatientAllergyHistory {
                      PatientAllergyHistoryID = 1,
                      PatientProfileID = 1,
                      AllergyReactions = new List<AllergyReaction>()
                }
            };
            PatientAllergyHistories.ForEach(s => context.PatientAllergyHistories.Add(s));
            context.SaveChanges();
            //
            PatientAllergyHistories[0].AllergyReactions.Add(AllergyReactions[0]);
            PatientAllergyHistories[0].AllergyReactions.Add(AllergyReactions[1]);
            context.SaveChanges();
            //
            //
            var DrugCategories = new List<DrugCategory>()
            {
                new DrugCategory {
                    DrugCategoryID = 1,
                    Category = "Cardiovascular agents",
                    Desc = "",
                    PartentCategroyID = 0
                },
                new DrugCategory {
                    DrugCategoryID = 2,
                    Category = "Antiarrhythmic agents",
                    Desc = "",
                    PartentCategroyID = 1
                },
                new DrugCategory {
                    DrugCategoryID = 3,
                    Category = "Group I antiarrhythmics",
                    Desc = "Group 1 antiarrhythmics: Sodium-channel blockers, which block the fast sodium channels, thereby slowing electrical conduction in the heart.",
                    PartentCategroyID = 2
                },
                new DrugCategory {
                    DrugCategoryID = 4,
                    Category = "Antineoplastics",
                    Desc = "",
                    PartentCategroyID = 0
                },
                new DrugCategory {
                    DrugCategoryID = 5,
                    Category = "Alkylating agents",
                    Desc = "",
                    PartentCategroyID = 4
                },
                new DrugCategory {
                    DrugCategoryID = 6,
                    Category = "Allergenics",
                    Desc = "",
                    PartentCategroyID = 0
                }
            };
            DrugCategories.ForEach(s => context.DrugCategories.Add(s));
            context.SaveChanges();
            //
            //
            var Drugs = new List<Drug>()
            {
                new Drug {
                    DrugID  = 1,
                    DrugCategoryID = 3, //Group I antiarrhythmics
                    Name = "Ethmozine",
                    GenericName = "moricizine", 
                    ClinicalUse ="",
                    Note = ""
                },
                new Drug {
                    DrugID  = 2,
                    DrugCategoryID = 3, //Group I antiarrhythmics
                    Name = "Quinaglute Dura-Tabs ",
                    GenericName = "quinidine",
                    ClinicalUse ="",
                    Note = ""
                },
                new Drug {
                    DrugID  = 3,
                    DrugCategoryID = 3, //Group I antiarrhythmics
                    Name = "Xylocaine HCl ",
                    GenericName = "lidocaine ",
                    ClinicalUse ="",
                    Note = ""
                },
                new Drug {
                    DrugID  = 4,
                    DrugCategoryID = 3, //Group I antiarrhythmics
                    Name = "Pronestyl",
                    GenericName = "procainamide ",
                    ClinicalUse ="",
                    Note = ""
                },
                new Drug {
                    DrugID  = 5,
                    DrugCategoryID = 5, //Alkylating agents
                    Name = "Platinol-AQ",
                    GenericName = "cisplatin  ",
                    ClinicalUse ="",
                    Note = ""
                },
                new Drug {
                    DrugID  = 6,
                    DrugCategoryID = 5, //Alkylating agents
                    Name = "Tepadina",
                    GenericName = "thiotepa",
                    ClinicalUse ="",
                    Note = ""
                },
                new Drug {
                    DrugID  = 7,
                    DrugCategoryID = 5, //Alkylating agents
                    Name = "Thioplex",
                    GenericName = "thiotepa",
                    ClinicalUse ="",
                    Note = ""
                },
                new Drug {
                    DrugID  = 8,
                    DrugCategoryID = 5, //Alkylating agents
                    Name = "Zanosar",
                    GenericName = "streptozocin",
                    ClinicalUse ="",
                    Note = ""
                },
                new Drug {
                    DrugID  = 9,
                    DrugCategoryID = 6, //Allergenics
                    Name = "Grastek",
                    GenericName = "timothy grass pollen allergen extract",
                    ClinicalUse ="",
                    Note = ""
                },
                new Drug {
                    DrugID  = 10,
                    DrugCategoryID = 6, //Allergenics
                    Name = "Ragwitek",
                    GenericName = "ragweed pollen allergen extract",
                    ClinicalUse ="",
                    Note = ""
                }
            };
            Drugs.ForEach(s => context.Drugs.Add(s));
            context.SaveChanges();
            //
            //
            var PatientDrugHistories = new List<PatientDrugHistory>()
            {
                new PatientDrugHistory {
                    PatientDrugHistoryID = 1,
                    PatientProfileID = 1,
                    DrugID = 1,
                    Dose = "20 mg pill",
                    HowOftenTaken = "twice a day",
                    HowLongTakenInMonth = 4
                },
                new PatientDrugHistory {
                    PatientDrugHistoryID = 2,
                    PatientProfileID = 1,
                    DrugID = 6,
                    Dose = "2 tablespoons",
                    HowOftenTaken = "every 6 hours",
                    HowLongTakenInMonth = 4
                }
            };
            PatientDrugHistories.ForEach(s => context.PatientDrugHistories.Add(s));
            context.SaveChanges();
        }
    }
}