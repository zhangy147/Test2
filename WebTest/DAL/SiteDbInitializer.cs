using System;
using System.Collections.Generic;
using System.Data.Entity;
using WebTest.Models;
using WebTest.Helpers;


namespace WebTest.DAL
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
                    CDesc = "乳房", ImageLink = "" },
                 new BodySystem { BodySystemID = 18, Name = "Blood System", CName = "血液系统", 
                    Desc = "Breast", 
                    CDesc = "血液系统", ImageLink = "" },
                new BodySystem { BodySystemID = 19, Name = "Infections", CName = "传染病", 
                    Desc = "disease caused by infection", 
                    CDesc = "传染病", ImageLink = "" },
                 new BodySystem { BodySystemID = 20, Name = "Psychiatric/psychosocial", CName = "精神/心理", 
                    Desc = "disease caused by infection", 
                    CDesc = "精神/心理", ImageLink = "" },
                new BodySystem { BodySystemID = 21, Name = "Other Heath Problem", CName = "其他健康问题", 
                    Desc = "Other heath problems or conditions", 
                    CDesc = "其他健康问题", ImageLink = "" }
            };
            BodySystems.ForEach(s => context.BodySystems.Add(s));
            context.SaveChanges();
            //
            var MedicalSpecialties = new List<MedicalSpecialty>
            {
                new MedicalSpecialty { MedicalSpecialtyID = 1, Name = "Allergy & Immunology", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 2, Name = "Anesthesiology", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 3, Name = "Surgery", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 4, Name = "Dermatology", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 5, Name = "Emergency Medicine", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 6, Name = "Internal Medicine", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 7, Name = "Neurology", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 8, Name = "Nuclear Medicine", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 9, Name = "Obstetrics and Gynecology", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 10, Name = "Otolaryngology", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 11, Name = "Pathology", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 12, Name = "Pediatrics", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 13, Name = "Physical Medicine and Rehabilitation", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 14, Name = "Psychiatry", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 15, Name = "Oncology", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 16, Name = "Radiation", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 17, Name = "Ophthalmology ", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 18, Name = "Orthopaedic Surgery", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 19, Name = "Cardiovascular Disease", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 20, Name = "Rheumatology", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 21, Name = "Infectious Disease ", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 22, Name = "Urology", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 23, Name = "Gastroenterology", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 24, Name = "Geriatric Medicine", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 25, Name = "Pulmonology", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 26, Name = "Nephrology", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 27, Name = "Hematology", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 28, Name = "Radiology", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 29, Name = "Geriatric Medicine", Desc = "" },
                new MedicalSpecialty { MedicalSpecialtyID = 30, Name = "Endocrinology", Desc = "" },
            };
            MedicalSpecialties.ForEach(s => context.MedicalSpecialties.Add(s));
            context.SaveChanges();
            //
            //
            var Diseases = new List<Disease>
            {
                new Disease {
                     DiseaseID = 1, 
                     Name = "Primary Hypertension",
                     CName = "原发性高血压",
                     Abbreviation = "PH",
                     BodySystemID = 2,
                     UsedForPMH = true,
                     UsedForFMH = true,
                     
                },
                new Disease {
                    DiseaseID = 2,
                    Name = "Diabetes",
                    CName = "糖尿病",
                    Abbreviation = "DB",
                    BodySystemID = 6,
                    UsedForPMH = true,
                    UsedForFMH = true,
                    
                },
                new Disease {
                    DiseaseID = 3,
                    Name = "Ruptured Aortic Aneurysm",
                    CName = "主动脉瘤破裂",
                    Abbreviation = "RAA",
                    BodySystemID = 2,
                    UsedForPMH = false,
                    UsedForFMH = false,
                    
                },
                new Disease {
                    DiseaseID = 4,
                    Name = "Acute Appendicitis",
                    CName = "急性阑尾炎",
                    Abbreviation = "AA",
                    BodySystemID = 3,
                    UsedForPMH = false,
                    UsedForFMH = false,
                    
                },
                new Disease {
                    DiseaseID = 5,
                    Name = "Diverticulitis",
                    CName = "结肠憩室炎",
                    Abbreviation = "DV",
                    BodySystemID = 3,
                    UsedForPMH = true,
                    UsedForFMH = false,
                    
                },
                new Disease {
                    DiseaseID = 6,
                    Name = "Gastroenteritis",
                    CName = "胃肠炎",
                    Abbreviation = "GA",
                    BodySystemID = 3,
                    UsedForPMH = false,
                    UsedForFMH = false,
                   
                },
                new Disease {
                    DiseaseID = 7,
                    Name = "Inflammatory Bowel Disease",
                    CName = "炎症性肠病",
                    Abbreviation = "IBD",
                    BodySystemID = 3,
                    UsedForPMH = true,
                    UsedForFMH = true,
                  
                },
                new Disease {
                    DiseaseID = 8,
                    Name = "Intestinal Obstruction",
                    CName = "肠梗阻",
                    Abbreviation = "IO",
                    BodySystemID = 3,
                    UsedForPMH = false,
                    UsedForFMH = false,
                   
                },
                new Disease {
                    DiseaseID = 9,
                    Name = "Pancreatitis",
                    CName = "胰腺炎",
                    Abbreviation = "PAN",
                    BodySystemID = 3,
                    UsedForPMH = true,
                    UsedForFMH = true,
                   
                },
                new Disease {
                    DiseaseID = 0,
                    Name = "Peptic Ulcer Disease",
                    CName = "消化性溃疡",
                    Abbreviation = "PUD",
                    BodySystemID = 3,
                    UsedForPMH = true,
                    UsedForFMH = true,
                   
                },
                new Disease {
                    DiseaseID = 1,
                    Name = "Pelvic Inflammatory Disease",
                    CName = "盆腔炎",
                    Abbreviation = "PID",
                    BodySystemID = 5,
                    UsedForPMH = true,
                    UsedForFMH = false,
                   
                },
                new Disease {
                    DiseaseID = 2,
                    Name = "Testicular Torsion",
                    CName = "睾丸扭转",
                    Abbreviation = "TT",
                    BodySystemID = 5,
                    UsedForPMH = false,
                    UsedForFMH = false,
                   
                },
                new Disease {
                    DiseaseID = 3,
                    Name = "Nephrolithiasis",
                    CName = "肾结石",    
                    Abbreviation = "NEP",
                    BodySystemID = 4,
                    UsedForPMH = true,
                    UsedForFMH = false,
                    
                }
            };
            Diseases.ForEach(s => context.Diseases.Add(s));
            context.SaveChanges();

            var Cancers = new List<Cancer>
            {
                new Cancer { DiseaseID = 14, Name = "Colon Cancer", Abbreviation = "Colon Cancer", Desc = "", 
                    CName = "结肠癌", BodySystemID = 3, 
                   
                },
                new Cancer { DiseaseID = 15, Name = "Non-Small Cell Lung Cancer", Abbreviation = "NSCLC", Desc = "", 
                    CName = "非小细胞肺癌",  BodySystemID = 1, 
                  
                },
                new Cancer { DiseaseID = 16, Name = "Gastric Cancer", Abbreviation = "Gastric Cancer", Desc = "", 
                    CName = "胃癌", BodySystemID = 3, 
                  
                },
                new Cancer { DiseaseID = 17, Name = "Breast Cancer", Abbreviation = "Breast Cancer", Desc = "", 
                    CName = "乳腺癌",  BodySystemID = 5, 
                 
                },
                new Cancer { DiseaseID = 18, Name = "Pancrea Cancer", Abbreviation = "Pancrea Cancer", Desc = "", 
                    CName = "胰腺癌",  BodySystemID = 3, 
                   
                },
                new Cancer { DiseaseID = 19, Name = "Hepatic Cancer", Abbreviation = "Heptical Cancer", Desc = "", 
                    CName = "肝癌", BodySystemID = 3, 
                  
                },
                new Cancer { DiseaseID = 20, Name = "Leukemia", Abbreviation = "Leukemia", Desc = "", 
                    CName = "白血病", BodySystemID = 18, 
                  
                },
                new Cancer { DiseaseID = 21, Name = "Non-Hodgkin Lymphoma", Abbreviation = "Non-Hodgkin Lymphoma", Desc = "", 
                    CName = "非霍奇金淋巴瘤",  BodySystemID = 8, 
                  
                }

            };
            Cancers.ForEach(c => context.Cancers.Add(c));
            context.SaveChanges();

            //
            var DiseaseAssignments = new List<DiseaseAssignment>
            {
                //oncology
                new DiseaseAssignment { DiseaseAssignmentID = 1, MedicalSpecialtyID = 15, DiseaseID = 14, IsPrimary = true },
                new DiseaseAssignment { DiseaseAssignmentID = 2, MedicalSpecialtyID = 15, DiseaseID = 15, IsPrimary = false },
                new DiseaseAssignment { DiseaseAssignmentID = 3, MedicalSpecialtyID = 15, DiseaseID = 16, IsPrimary = true },
                new DiseaseAssignment { DiseaseAssignmentID = 4, MedicalSpecialtyID = 15, DiseaseID = 17, IsPrimary = false },
                new DiseaseAssignment { DiseaseAssignmentID = 5, MedicalSpecialtyID = 15, DiseaseID = 18, IsPrimary = true },
                new DiseaseAssignment { DiseaseAssignmentID = 6, MedicalSpecialtyID = 15, DiseaseID = 19, IsPrimary = true },
                new DiseaseAssignment { DiseaseAssignmentID = 7, MedicalSpecialtyID = 15, DiseaseID = 20, IsPrimary = true },
                new DiseaseAssignment { DiseaseAssignmentID = 8, MedicalSpecialtyID = 15, DiseaseID = 21, IsPrimary = true },
                //cardiovascular
                new DiseaseAssignment { DiseaseAssignmentID = 9, MedicalSpecialtyID = 19, DiseaseID = 1, IsPrimary = true },
                new DiseaseAssignment { DiseaseAssignmentID = 10, MedicalSpecialtyID = 19, DiseaseID = 3, IsPrimary = true },
                //endocrinology
                new DiseaseAssignment { DiseaseAssignmentID = 11, MedicalSpecialtyID = 30, DiseaseID = 2, IsPrimary = true },
                //gastroenterology
                new DiseaseAssignment { DiseaseAssignmentID = 12, MedicalSpecialtyID = 23, DiseaseID = 4, IsPrimary = false },
                new DiseaseAssignment { DiseaseAssignmentID = 13, MedicalSpecialtyID = 23, DiseaseID = 5, IsPrimary = false },
                new DiseaseAssignment { DiseaseAssignmentID = 14, MedicalSpecialtyID = 23, DiseaseID = 6, IsPrimary = false },
                new DiseaseAssignment { DiseaseAssignmentID = 15, MedicalSpecialtyID = 23, DiseaseID = 7, IsPrimary = false },
                new DiseaseAssignment { DiseaseAssignmentID = 16, MedicalSpecialtyID = 23, DiseaseID = 8, IsPrimary = false },
                new DiseaseAssignment { DiseaseAssignmentID = 17, MedicalSpecialtyID = 23, DiseaseID = 9, IsPrimary = false },
                new DiseaseAssignment { DiseaseAssignmentID = 18, MedicalSpecialtyID = 23, DiseaseID = 10, IsPrimary = false },
                //GY
                new DiseaseAssignment { DiseaseAssignmentID = 19, MedicalSpecialtyID = 9, DiseaseID = 11, IsPrimary = false },
                //
                new DiseaseAssignment { DiseaseAssignmentID = 20, MedicalSpecialtyID = 22, DiseaseID = 12, IsPrimary = false },
                new DiseaseAssignment { DiseaseAssignmentID = 21, MedicalSpecialtyID = 22, DiseaseID = 13, IsPrimary = false },
            };
            DiseaseAssignments.ForEach(s => context.DiseaseAssignments.Add(s));
            context.SaveChanges();
            //

            //
            var RequiredDiseaseHistories = new List<RequiredDiseaseHistory> 
            {
                new RequiredDiseaseHistory { RequiredDiseaseHistoryID = 1, MedicalSpecialtyID = 15, UserGroupID = 0, DiseaseID = 14 },
                new RequiredDiseaseHistory { RequiredDiseaseHistoryID = 2, MedicalSpecialtyID = 15, UserGroupID = 0, DiseaseID = 15 },
                new RequiredDiseaseHistory { RequiredDiseaseHistoryID = 3, MedicalSpecialtyID = 15, UserGroupID = 0, DiseaseID = 16 },
                new RequiredDiseaseHistory { RequiredDiseaseHistoryID = 4, MedicalSpecialtyID = 15, UserGroupID = 0, DiseaseID = 17 },
                new RequiredDiseaseHistory { RequiredDiseaseHistoryID = 5, MedicalSpecialtyID = 15, UserGroupID = 0, DiseaseID = 18 },
                new RequiredDiseaseHistory { RequiredDiseaseHistoryID = 6, MedicalSpecialtyID = 15, UserGroupID = 0, DiseaseID = 19 },
                new RequiredDiseaseHistory { RequiredDiseaseHistoryID = 7, MedicalSpecialtyID = 15, UserGroupID = 0, DiseaseID = 20 },
                new RequiredDiseaseHistory { RequiredDiseaseHistoryID = 8, MedicalSpecialtyID = 15, UserGroupID = 0, DiseaseID = 21 },
                new RequiredDiseaseHistory { RequiredDiseaseHistoryID = 9, MedicalSpecialtyID = 23, UserGroupID = 0, DiseaseID = 4 },
                new RequiredDiseaseHistory { RequiredDiseaseHistoryID = 10, MedicalSpecialtyID = 23, UserGroupID = 0, DiseaseID = 14 }
            };
            RequiredDiseaseHistories.ForEach(c => context.RequiredDiseaseHistories.Add(c));
            context.SaveChanges();


            var Services = new List<Service>
            {
                new Service { 
                    ServiceID = 1, ServiceName = "Expert Second Opinion", ServiceName_ZH = "医疗第二意见", 
                    ServiceDesc = "", 
                    ServiceDesc_ZH = "",
                    AllowChooseProvider = true
                },
                new Service { 
                    ServiceID = 2, ServiceName = "Live Online Consulting", ServiceName_ZH = "在线医疗咨询", 
                    ServiceDesc = "", 
                    ServiceDesc_ZH = "",
                    AllowChooseProvider = false
                },
                new Service { 
                    ServiceID = 3, ServiceName = "Best Treatment Report", ServiceName_ZH = "最佳疗法报告", 
                    ServiceDesc = "", 
                    ServiceDesc_ZH = "",
                    AllowChooseProvider = false
                },
                new Service { 
                    ServiceID = 4, ServiceName = "Obtain Treatment In USA", ServiceName_ZH = "来美就医服务", 
                    ServiceDesc = "", 
                    ServiceDesc_ZH = "",
                    AllowChooseProvider = false
                }
            };
            Services.ForEach(s => context.Services.Add(s));
            context.SaveChanges();
            //

            var Providers = new List<Provider>
            { 
                new Provider {
                    ProviderID = 1, 
                    ProviderName = "Cleveland Clinic", 
                    ProviderName_ZH = "克利夫兰诊所",
                },
                new Provider {
                    ProviderID = 2, 
                    ProviderName = "OSU Wexner Medical Center", 
                    ProviderName_ZH = "俄亥俄州立大学Wexner医学中心",
                },
                new Provider {
                    ProviderID = 3, 
                    ProviderName = "Our Contracted Specialists", 
                    ProviderName_ZH = "公司特约医学专家",
                }
            };
            Providers.ForEach(s => context.Providers.Add(s));
            context.SaveChanges();
            //
            var ServiceProviders = new List<ServiceProvider>
            {  
                new ServiceProvider {
                    ServiceProviderID = 1, ServiceID = 1, ProviderID = 1
                },
                new ServiceProvider {
                    ServiceProviderID = 2, ServiceID = 1, ProviderID = 2
                },
                new ServiceProvider {
                    ServiceProviderID = 3, ServiceID = 1, ProviderID = 3
                },
                new ServiceProvider {
                    ServiceProviderID = 4, ServiceID = 2, ProviderID = 3
                },
                new ServiceProvider {
                    ServiceProviderID = 5, ServiceID = 3, ProviderID = 3
                }
            };
            ServiceProviders.ForEach(s => context.ServiceProviders.Add(s));
            context.SaveChanges();
            //
            //
            var Treatments = new List<Treatment>()
            {
                new Treatment { TreatmentID = 1, Name = "Glossectomy", Desc = "Glossectomy", Modality = TreatmentModality.Surgery },
                new Treatment { TreatmentID = 2, Name = "Esophagectomy", Desc = "Esophagectomy", Modality = TreatmentModality.Surgery },
                new Treatment { TreatmentID = 3, Name = "Appendectomy", Desc = "Appendectomy", Modality = TreatmentModality.Surgery },
                new Treatment { TreatmentID = 4, Name = "Colectomy", Desc = "Colectomy", Modality = TreatmentModality.Surgery },
                new Treatment { TreatmentID = 5, Name = "Cholecystectomy", Desc = "Glossectomy", Modality = TreatmentModality.Surgery },
                new Treatment { TreatmentID = 6, Name = "Pancreatectomy", Desc = "Pancreatectomy", Modality = TreatmentModality.Surgery },
                new Treatment { TreatmentID = 7, Name = "Gastrostomy", Desc = "Gastrostomy", Modality = TreatmentModality.Surgery },
                new Treatment { TreatmentID = 8, Name = "Gastroduodenostomy", Desc = "Gastroduodenostomy", Modality = TreatmentModality.Surgery },
                new Treatment { TreatmentID = 9, Name = "Colostomy", Desc = "Colostomy", Modality = TreatmentModality.Surgery },
                new Treatment { TreatmentID = 10, Name = "Cholecystostomy", Desc = "Cholecystostomy" },
                new Treatment { TreatmentID = 11, Name = "Hepatoportoenterostomy", Desc = "Hepatoportoenterostomy", Modality = TreatmentModality.Surgery },
                new Treatment { TreatmentID = 12, Name = "Colon resection", Desc = "Colon resection", Modality = TreatmentModality.Surgery },
                new Treatment { TreatmentID = 13, Name = "Hernia repair", Desc = "Hernia repair", Modality = TreatmentModality.Surgery },
                new Treatment { TreatmentID = 14, Name = "Liver biopsy", Desc = "Liver biopsy", Modality = TreatmentModality.Surgery },
                new Treatment { TreatmentID = 15, Name = "Heart transplantation", Desc = "Heart transplantation", Modality = TreatmentModality.Surgery },
            };
            Treatments.ForEach(s => context.Treatments.Add(s));
            context.SaveChanges();
            //
            var RequiredSurgicalHistories = new List<RequiredSurgicalHistory>{
                new RequiredSurgicalHistory { RequiredSurgicalHistoryID = 1, MedicalSpecialtyID = 15, UserGroupID = 0, TreatmentID = 1 },
                new RequiredSurgicalHistory { RequiredSurgicalHistoryID = 2, MedicalSpecialtyID = 15, UserGroupID = 0, TreatmentID = 2 },
                new RequiredSurgicalHistory { RequiredSurgicalHistoryID = 3, MedicalSpecialtyID = 15, UserGroupID = 0, TreatmentID = 3 },
                new RequiredSurgicalHistory { RequiredSurgicalHistoryID = 4, MedicalSpecialtyID = 15, UserGroupID = 0, TreatmentID = 4 },
                new RequiredSurgicalHistory { RequiredSurgicalHistoryID = 5, MedicalSpecialtyID = 15, UserGroupID = 0, TreatmentID = 5 },
                new RequiredSurgicalHistory { RequiredSurgicalHistoryID = 6, MedicalSpecialtyID = 15, UserGroupID = 0, TreatmentID = 6 },
                new RequiredSurgicalHistory { RequiredSurgicalHistoryID = 7, MedicalSpecialtyID = 15, UserGroupID = 0, TreatmentID = 7 },
                new RequiredSurgicalHistory { RequiredSurgicalHistoryID = 8, MedicalSpecialtyID = 15, UserGroupID = 0, TreatmentID = 8 },
                new RequiredSurgicalHistory { RequiredSurgicalHistoryID = 9, MedicalSpecialtyID = 15, UserGroupID = 0, TreatmentID = 10 },
                new RequiredSurgicalHistory { RequiredSurgicalHistoryID = 10, MedicalSpecialtyID = 1, UserGroupID = 0, TreatmentID = 11 },
                new RequiredSurgicalHistory { RequiredSurgicalHistoryID = 11, MedicalSpecialtyID = 1, UserGroupID = 0, TreatmentID = 12 },
                new RequiredSurgicalHistory { RequiredSurgicalHistoryID = 12, MedicalSpecialtyID = 1, UserGroupID = 0, TreatmentID = 13 },
                new RequiredSurgicalHistory { RequiredSurgicalHistoryID = 13, MedicalSpecialtyID = 1, UserGroupID = 0, TreatmentID = 14 },
                new RequiredSurgicalHistory { RequiredSurgicalHistoryID = 14, MedicalSpecialtyID = 1, UserGroupID = 0, TreatmentID = 15 },
            };
            RequiredSurgicalHistories.ForEach(s => context.RequiredSurgicalHistories.Add(s));
            context.SaveChanges();
            //

            //
            var PatientProfiles = new List<PatientProfile>
            {
                new PatientProfile { 
                    PatientProfileID = 1,  
                    UserID = 100, 
                    Age = 62, 
                    Ethnic = EnumHelper.EthnicGroups[2],
                    Gender = EnumHelper.Genders[0], 
                    DiseaseID = 14, 
                    //DateDiagnosed = DateTime.Parse("2012-05-06"), 
                    DateDiagnosed = "05/2012", 
                    HospitalDiagnosisMade = "MCO Medical Center",
                    //CurrentSituation = "colon cancer with stage IV",
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
                    Ethnic = EnumHelper.EthnicGroups[2],
                    Gender = EnumHelper.Genders[1], 
                    DiseaseID = 4, 
                    //DateDiagnosed = DateTime.Parse("2011-08-06"), 
                    DateDiagnosed = "08/2011", 
                    HospitalDiagnosisMade = "Beijing Fouth District Hospital",
                    //CurrentSituation = "Complicated with diabetes, want to konw how to adjust doses of chemotherapy",
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
            //PatientProfiles[0].DiseaseTreatmentIndications.Add(DiseaseTreatmentIndications[0]);
            //PatientProfiles[0].DiseaseTreatmentIndications.Add(DiseaseTreatmentIndications[2]);
            //PatientProfiles[0].DiseaseTreatmentIndications.Add(DiseaseTreatmentIndications[5]);
            //PatientProfiles[0].DiseaseTreatmentIndications.Add(DiseaseTreatmentIndications[6]);
            ////
            ////patient 2
            //PatientProfiles[1].DiseaseTreatmentIndications.Add(DiseaseTreatmentIndications[27]);
            //PatientProfiles[1].DiseaseTreatmentIndications.Add(DiseaseTreatmentIndications[25]);
            ////PatientProfiles[1].DiseaseTreatmentIndications.Add(DiseaseTreatmentIndications[5]);
            ////PatientProfiles[1].DiseaseTreatmentIndications.Add(DiseaseTreatmentIndications[7]);
            ////PatientProfiles[1].DiseaseTreatmentIndications.Add(DiseaseTreatmentIndications[10]);
            ////context.SaveChanges();
            //
            //var RequestedServices = new List<RequestedService>()
            //{
            //    new RequestedService {
            //        RequestedServiceID = 1,
            //        ServiceID = 1,
            //        ProviderID = 3,
            //        PatientProfileID = 1,
            //        InsertDate = DateTime.Parse("2015-02-21"), 
            //    },
            //    new RequestedService {
            //        RequestedServiceID = 2,
            //        ServiceID = 3,
            //        ProviderID = 3,
            //        PatientProfileID = 1,
            //        InsertDate = DateTime.Parse("2015-02-21"), 
            //    }

            //};
            //RequestedServices.ForEach(s => context.RequestedServices.Add(s));
            //context.SaveChanges();


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
                    Question = "Should I try herbs treatment during chemotherapy?",
                    DateAsked = DateTime.Parse("2015-03-04"), 
                    Answer = "Herbs may increase or decrese the enzyme activities in your liver, these effects may reduce or enhance the effects and toxicities of chemotherapy. So refraining from herbs during active chemothaepy is better.",
                    DateAnswered = DateTime.Parse("2015-03-05"), 
                    AnswererID = 1
                },
                new PatientQuestion {
                    PatientQuestionID = 2,
                    PatientProfileID = 1,
                    Question = "When should I stop chemotherapy?",
                    DateAsked = DateTime.Parse("2015-03-06"), 
                    Answer = "The firstline chemotherapy shoul continue 6 months before deciding to continue, discontinue or change to other treatment.",
                    DateAnswered = DateTime.Parse("2015-03-15"), 
                    AnswererID = 3
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
                   
                },
                new MedicalRecord {
                    MedicalRecordID = 2,
                    Name = "Notation of medications",
                    Type = "",
                    Desc = "Listing of all medications prescribed by doctor, including prescription, over teh counter, vitamin, supplement and herb product",
                    
                },
                new MedicalRecord {
                    MedicalRecordID = 3,
                    Name = "Report from pathologist",
                    Type = "",
                    Desc = "Report and glass slides from pathologist or department of pathology about all body samples or biopsies.",
                  
                },
                new MedicalRecord {
                    MedicalRecordID = 4,
                    Name = "Surgical report",
                    Type = "",
                    Desc = "Report created by surgeons after surgery relevent to patient current situation.",
                   
                },
                new MedicalRecord {
                    MedicalRecordID = 5,
                    Name = "Physician treatment plan",
                    Type = "",
                    Desc = "All treatment plans for current diagnosis including chemptherapy, radiation therapy, etc. The plan should document medication, dosage, schedule, treatment duration.",
                   
                },
                new MedicalRecord {
                    MedicalRecordID = 6,
                    Name = "Discharge summary",
                    Type = "",
                    Desc = "Discharge summary from any recent (within one year) hospitalization(s).",
                   
                },
                new MedicalRecord {
                    MedicalRecordID = 7,
                    Name = "Current blood work",
                    Type = "",
                    Desc = "Blood test report relevant to patient current disease within past 6 months",
                    
                },
                new MedicalRecord {
                    MedicalRecordID = 8,
                    Name = "Chest X-ray, PA and lateral views",
                    Type = "",
                    Desc = "Diagnostic or pre-treatment evaluation procedure report relevant to patient current disease",
                   
                },
                new MedicalRecord {
                    MedicalRecordID = 9,
                    Name = "Brain MRI",
                    Type = "",
                    Desc = "Diagnostic or pre-treatment evaluation procedure report",
                    
                }
            };
            MedicalRecords.ForEach(s => context.MedicalRecords.Add(s));
            context.SaveChanges();
            
            //
            var DiseaseMedicalRecords = new List<DiseaseMedicalRecord>() {
                new DiseaseMedicalRecord {
                    DiseaseMedicalRecordID = 1, DiseaseID = 4, MedicalRecordID = 1, IsMandatory = true
                },
                new DiseaseMedicalRecord {
                    DiseaseMedicalRecordID = 2, DiseaseID = 4, MedicalRecordID = 2, IsMandatory = true
                },
                new DiseaseMedicalRecord {
                    DiseaseMedicalRecordID = 3, DiseaseID = 4, MedicalRecordID = 3, IsMandatory = true
                },
                new DiseaseMedicalRecord {
                    DiseaseMedicalRecordID = 4, DiseaseID = 4, MedicalRecordID = 4, IsMandatory = false
                },
                new DiseaseMedicalRecord {
                    DiseaseMedicalRecordID = 5, DiseaseID = 4, MedicalRecordID = 5, IsMandatory = true
                },
                new DiseaseMedicalRecord {
                    DiseaseMedicalRecordID = 6, DiseaseID = 4, MedicalRecordID = 6, IsMandatory = true
                },
                new DiseaseMedicalRecord {
                    DiseaseMedicalRecordID = 7, DiseaseID = 4, MedicalRecordID = 7, IsMandatory = true
                },
                new DiseaseMedicalRecord {
                    DiseaseMedicalRecordID = 8, DiseaseID = 4, MedicalRecordID = 8, IsMandatory = true
                },
                new DiseaseMedicalRecord {
                    DiseaseMedicalRecordID = 9, DiseaseID = 4, MedicalRecordID = 9, IsMandatory = false
                }
            };
            DiseaseMedicalRecords.ForEach(s => context.DiseaseMedicalRecords.Add(s));
            context.SaveChanges();

            var RequiredMedicalRecords = new List<RequiredMedicalRecord>() {
                new RequiredMedicalRecord {
                    RequiredMedicalRecordID = 1, UserGroupID = 0, DiseaseMedicalRecordID = 1
                },
                new RequiredMedicalRecord {
                    RequiredMedicalRecordID = 2, UserGroupID = 0, DiseaseMedicalRecordID = 2
                },
                new RequiredMedicalRecord {
                    RequiredMedicalRecordID = 3, UserGroupID = 0, DiseaseMedicalRecordID = 3
                },
                new RequiredMedicalRecord {
                    RequiredMedicalRecordID = 4, UserGroupID = 0, DiseaseMedicalRecordID = 4
                },
                new RequiredMedicalRecord {
                    RequiredMedicalRecordID = 5, UserGroupID = 0, DiseaseMedicalRecordID = 5
                },
                new RequiredMedicalRecord {
                    RequiredMedicalRecordID = 6, UserGroupID = 0, DiseaseMedicalRecordID = 6
                },
                new RequiredMedicalRecord {
                    RequiredMedicalRecordID = 7, UserGroupID = 0, DiseaseMedicalRecordID = 7
                },
            };
            RequiredMedicalRecords.ForEach(s => context.RequiredMedicalRecords.Add(s));
            context.SaveChanges();
            //
            var PatientDiseaseHistories = new List<PatientDiseaseHistory>() {
                new PatientDiseaseHistory {
                    PatientDiseaseHistoryID = 1,
                    PatientProfileID = 1,
                    RequiredDiseaseHistoryID = 1,
                    DateDiagnosed =  DateTime.Parse("2010-12-16"),
                    PatientNote = ""
                },
                new PatientDiseaseHistory {
                    PatientDiseaseHistoryID = 2,
                    PatientProfileID = 1,
                    RequiredDiseaseHistoryID = 2,
                    DateDiagnosed =  DateTime.Parse("2011-5-6"),
                    PatientNote = ""
                }
            };
            PatientDiseaseHistories.ForEach(s => context.PatientDiseaseHistories.Add(s));
            context.SaveChanges();
            //
            var PatientSurgicalHistories = new List<PatientSurgicalHistory>() {
                new PatientSurgicalHistory {
                    PatientSurgicalHistoryID = 1,
                    PatientProfileID = 1,
                    RequiredSurgicalHistoryID = 1,
                    DatePerformed = DateTime.Parse("2008-2-16"),
                    PatientNote = ""
                },
                new PatientSurgicalHistory {
                    PatientSurgicalHistoryID = 2,
                    PatientProfileID = 1,
                    RequiredSurgicalHistoryID = 4,
                    DatePerformed = DateTime.Parse("2011-12-6"),
                    PatientNote = ""
                },
            };
            PatientSurgicalHistories.ForEach(s => context.PatientSurgicalHistories.Add(s));
            context.SaveChanges();
            //
            var RequiredMedicalCondtionHistories = new List<RequiredMedicalConditionHistory> 
            {
                new RequiredMedicalConditionHistory { RequiredMedicalConditionHistoryID = 1, MedicalSpecialtyID = 15, PhysicianGroupID = 0, BodySystemID = 14, MedicalCondition = "Obesity" },
                new RequiredMedicalConditionHistory { RequiredMedicalConditionHistoryID = 2, MedicalSpecialtyID = 15, PhysicianGroupID = 0, BodySystemID = 14, MedicalCondition = "Weight Loss" },
                new RequiredMedicalConditionHistory { RequiredMedicalConditionHistoryID = 3, MedicalSpecialtyID = 15, PhysicianGroupID = 0, BodySystemID = 14, MedicalCondition = "None" },
                new RequiredMedicalConditionHistory { RequiredMedicalConditionHistoryID = 4, MedicalSpecialtyID = 15, PhysicianGroupID = 0, BodySystemID = 11, MedicalCondition = "Skin problem" },
                new RequiredMedicalConditionHistory { RequiredMedicalConditionHistoryID = 5, MedicalSpecialtyID = 15, PhysicianGroupID = 0, BodySystemID = 11, MedicalCondition = "Tumors or moles" },
                new RequiredMedicalConditionHistory { RequiredMedicalConditionHistoryID = 6, MedicalSpecialtyID = 15, PhysicianGroupID = 0, BodySystemID = 11, MedicalCondition = "Skin Biopsies" },
                new RequiredMedicalConditionHistory { RequiredMedicalConditionHistoryID = 7, MedicalSpecialtyID = 15, PhysicianGroupID = 0, BodySystemID = 11, MedicalCondition = "None" },
                new RequiredMedicalConditionHistory { RequiredMedicalConditionHistoryID = 8, MedicalSpecialtyID = 15, PhysicianGroupID = 0, BodySystemID = 16, MedicalCondition = "Head Injury" },
                new RequiredMedicalConditionHistory { RequiredMedicalConditionHistoryID = 9, MedicalSpecialtyID = 15, PhysicianGroupID = 0, BodySystemID = 16, MedicalCondition = "Migraine or chronic headaches" },
                new RequiredMedicalConditionHistory { RequiredMedicalConditionHistoryID = 10, MedicalSpecialtyID = 15, PhysicianGroupID = 0, BodySystemID = 16, MedicalCondition = "Deafness or hearing loss" },
                new RequiredMedicalConditionHistory { RequiredMedicalConditionHistoryID = 11, MedicalSpecialtyID = 15, PhysicianGroupID = 0, BodySystemID = 16, MedicalCondition = "Stroke or TIA" },
                new RequiredMedicalConditionHistory { RequiredMedicalConditionHistoryID = 12, MedicalSpecialtyID = 15, PhysicianGroupID = 0, BodySystemID = 16, MedicalCondition = "Earches" },
                new RequiredMedicalConditionHistory { RequiredMedicalConditionHistoryID = 13, MedicalSpecialtyID = 15, PhysicianGroupID = 0, BodySystemID = 16, MedicalCondition = "Frequent nose bleeding" },
                new RequiredMedicalConditionHistory { RequiredMedicalConditionHistoryID = 14, MedicalSpecialtyID = 15, PhysicianGroupID = 0, BodySystemID = 16, MedicalCondition = "Chronic sore throat" },
                new RequiredMedicalConditionHistory { RequiredMedicalConditionHistoryID = 15, MedicalSpecialtyID = 15, PhysicianGroupID = 0, BodySystemID = 16, MedicalCondition = "Blindness" },
                new RequiredMedicalConditionHistory { RequiredMedicalConditionHistoryID = 16, MedicalSpecialtyID = 15, PhysicianGroupID = 0, BodySystemID = 16, MedicalCondition = "Throat problems" },
                new RequiredMedicalConditionHistory { RequiredMedicalConditionHistoryID = 17, MedicalSpecialtyID = 15, PhysicianGroupID = 0, BodySystemID = 16, MedicalCondition = "None" },
                new RequiredMedicalConditionHistory { RequiredMedicalConditionHistoryID = 18, MedicalSpecialtyID = 15, PhysicianGroupID = 0, BodySystemID = 16, MedicalCondition = "Glaucoma" },
                new RequiredMedicalConditionHistory { RequiredMedicalConditionHistoryID = 19, MedicalSpecialtyID = 15, PhysicianGroupID = 0, BodySystemID = 15, MedicalCondition = "Cataracts" },
                new RequiredMedicalConditionHistory { RequiredMedicalConditionHistoryID = 20, MedicalSpecialtyID = 15, PhysicianGroupID = 0, BodySystemID = 15, MedicalCondition = "None" },
                new RequiredMedicalConditionHistory { RequiredMedicalConditionHistoryID = 21, MedicalSpecialtyID = 15, PhysicianGroupID = 0, BodySystemID = 1, MedicalCondition = "Asthma" },
                new RequiredMedicalConditionHistory { RequiredMedicalConditionHistoryID = 22, MedicalSpecialtyID = 15, PhysicianGroupID = 0, BodySystemID = 1, MedicalCondition = "Chronic bronchitis" },
                new RequiredMedicalConditionHistory { RequiredMedicalConditionHistoryID = 23, MedicalSpecialtyID = 15, PhysicianGroupID = 0, BodySystemID = 1, MedicalCondition = "Emphysema" },
                new RequiredMedicalConditionHistory { RequiredMedicalConditionHistoryID = 24, MedicalSpecialtyID = 15, PhysicianGroupID = 0, BodySystemID = 1, MedicalCondition = "Pulmonary emboli" },
                new RequiredMedicalConditionHistory { RequiredMedicalConditionHistoryID = 25, MedicalSpecialtyID = 15, PhysicianGroupID = 0, BodySystemID = 1, MedicalCondition = "None" }
            };
            RequiredMedicalCondtionHistories.ForEach(c => context.RequiredMedicalConditionHistories.Add(c));
            context.SaveChanges();

            var PatientMedicalConditionHistories = new List<PatientMedicalConditionHistory>() {
                new PatientMedicalConditionHistory {
                    PatientMedicalConditionHistoryID = 1,
                    PatientProfileID = 2,
                    RequiredMedicalConditionHistoryID = 2,
                    DateDiagnosed =  DateTime.Parse("2010-12-16"),
                    PatientNote = ""
                },
                new PatientMedicalConditionHistory {
                    PatientMedicalConditionHistoryID = 2,
                    PatientProfileID = 2,
                    RequiredMedicalConditionHistoryID = 8,
                    DateDiagnosed =  DateTime.Parse("2011-5-6"),
                    PatientNote = ""
                }
            };
            PatientMedicalConditionHistories.ForEach(s => context.PatientMedicalConditionHistories.Add(s));
            context.SaveChanges();
 
            var PatientMedicationHistories = new List<PatientMedicationHistory>()
            {
                new PatientMedicationHistory {
                    PatientMedicationHistoryID = 1,
                    PatientProfileID = 1,
                    Dose = "20 mg pill",
                    HowOftenTaken = "twice a day",
                    HowLongTakenInMonth = 4,
                    ReasonToTake = "cold"
                },
                new PatientMedicationHistory {
                    PatientMedicationHistoryID = 2,
                    PatientProfileID = 1,
                    Dose = "2 table spoons",
                    HowOftenTaken = "every 6 hours",
                    HowLongTakenInMonth = 4,
                    ReasonToTake = "fever"
                }
            };
            PatientMedicationHistories.ForEach(s => context.PatientMedicationHistories.Add(s));
            context.SaveChanges();
            //
            var PatientAllergyHistories = new List<PatientAllergyHistory>()
            {
                new PatientAllergyHistory {
                    PatientAllergyHistoryID = 1,
                    PatientProfileID = 2,
                    AntigenName = "Asprin",
                    IsMedicine = true,
                    Reaction = "skin rash all over the body",
                    YearDiscovered = 2012
                },
                new PatientAllergyHistory {
                    PatientAllergyHistoryID = 2,
                    PatientProfileID = 2,
                    AntigenName = "cat",
                    IsMedicine = false,
                    Reaction = "sneesing and caugh",
                    YearDiscovered = 2003
                }
            };
            PatientAllergyHistories.ForEach(s => context.PatientAllergyHistories.Add(s));
            context.SaveChanges();
            //
            var DiagnosticFactors = new List<DiagnosticFactor>
            {
                //system id=14
                new DiagnosticFactor { 
                    DiagnosticFactorID = 1, 
                    Name = "Fever", 
                    Desc = "Faver",
                    CName = "发烧",
                    CDesc = "发烧",
                    Type = DiagnosticFactorType.Symptom,
                    BodySystemID = 14
                },
                new DiagnosticFactor { 
                    DiagnosticFactorID = 2, 
                    Name = "Chills", 
                    Desc = "Chills",
                    CName = "畏寒",
                    CDesc = "畏寒",
                    Type = DiagnosticFactorType.Symptom,
                    BodySystemID = 14
                },
                new DiagnosticFactor { 
                    DiagnosticFactorID = 3, 
                    Name = "Weight loss", 
                    Desc = "Weight loss",
                    CName = "体重",
                    CDesc = "体重",
                    Type = DiagnosticFactorType.Symptom,
                    BodySystemID = 14
                },
                new DiagnosticFactor { 
                    DiagnosticFactorID = 4, 
                    Name = "Headache", 
                    Desc = "Headache",
                    CName = "头痛",
                    CDesc = "头痛",
                    Type = DiagnosticFactorType.Symptom,
                    BodySystemID = 14
                },
                //Eyes = 15
                new DiagnosticFactor { 
                    DiagnosticFactorID = 5, 
                    Name = "Blurred vision", 
                    Desc = "Blurred vision",
                    CName = "视力模糊",
                    CDesc = "视力模糊",
                    Type = DiagnosticFactorType.Symptom,
                    BodySystemID = 15
                },
                new DiagnosticFactor { 
                    DiagnosticFactorID = 6, 
                    Name = "Double vision", 
                    Desc = "Double vision",
                    CName = "双瞳",
                    CDesc = "双瞳",
                    Type = DiagnosticFactorType.Symptom,
                    BodySystemID = 15
                },
                new DiagnosticFactor { 
                    DiagnosticFactorID = 7, 
                    Name = "Vision changes", 
                    Desc = "Vision changes",
                    CName = "视力变化",
                    CDesc = "视力变化",
                    Type = DiagnosticFactorType.Symptom,
                    BodySystemID = 15
                },
                //Cardiovascular = 2
                new DiagnosticFactor { 
                    DiagnosticFactorID = 8, 
                    Name = "Chest pain", 
                    Desc = "Chest pain",
                    CName = "胸痛",
                    CDesc = "胸痛",
                    Type = DiagnosticFactorType.Symptom,
                    BodySystemID = 2
                },
                new DiagnosticFactor { 
                    DiagnosticFactorID = 9, 
                    Name = "Difficulty breathing", 
                    Desc = "Difficulty breathing",
                    CName = "呼吸困难",
                    CDesc = "呼吸困难",
                    Type = DiagnosticFactorType.Symptom,
                    BodySystemID = 2
                },

                new DiagnosticFactor { 
                    DiagnosticFactorID = 10, 
                    Name = "Swelling", 
                    Desc = "Swelling",
                    CName = "肿胀",
                    CDesc = "肿胀",
                    Type = DiagnosticFactorType.Symptom,
                    BodySystemID = 2
                },

                new DiagnosticFactor { 
                    DiagnosticFactorID = 11, 
                    Name = "Palpitation", 
                    Desc = "Palpitation",
                    CName = "心慌",
                    CDesc = "心慌",
                    Type = DiagnosticFactorType.Symptom,
                    BodySystemID = 2
                },
                //Digestive = 3
                new DiagnosticFactor { 
                    DiagnosticFactorID = 12, 
                    Name = "Nausea/vomiting", 
                    Desc = "Nausea/vomitingn",
                    CName = "恶心/呕吐",
                    CDesc = "恶心/呕吐",
                    Type = DiagnosticFactorType.Symptom,
                    BodySystemID = 3
                },
                new DiagnosticFactor { 
                    DiagnosticFactorID = 13, 
                    Name = "Constipation", 
                    Desc = "Constipation",
                    CName = "便秘",
                    CDesc = "便秘",
                    Type = DiagnosticFactorType.Symptom,
                    BodySystemID = 3
                },
                new DiagnosticFactor { 
                    DiagnosticFactorID = 14, 
                    Name = "Diarrhea", 
                    Desc = "Diarrhea",
                    CName = "腹泻",
                    CDesc = "腹泻",
                    Type = DiagnosticFactorType.Symptom,
                    BodySystemID = 3
                },
                new DiagnosticFactor { 
                    DiagnosticFactorID = 15, 
                    Name = "Abdominal pain", 
                    Desc = "Abdominal pain",
                    CName = "腹痛",
                    CDesc = "腹痛",
                    Type = DiagnosticFactorType.Symptom,
                    BodySystemID = 3
                },
            };
            DiagnosticFactors.ForEach(s => context.DiagnosticFactors.Add(s));
            context.SaveChanges();
            //
            //
            var RequiredSystemReviews = new List<RequiredSystemReview>()
            {
                new RequiredSystemReview {
                    RequiredSystemReviewID = 1, MedicalSpecialtyID = 15,  UserGroupID = 0, DiagnosticFactorID = 1
                },
                new RequiredSystemReview {
                    RequiredSystemReviewID = 2, MedicalSpecialtyID = 15,  UserGroupID = 0, DiagnosticFactorID = 2
                },
                new RequiredSystemReview {
                    RequiredSystemReviewID = 3, MedicalSpecialtyID = 15,  UserGroupID = 0, DiagnosticFactorID = 3
                },
                new RequiredSystemReview {
                    RequiredSystemReviewID = 4, MedicalSpecialtyID = 15,  UserGroupID = 0, DiagnosticFactorID = 4
                },
                new RequiredSystemReview {
                    RequiredSystemReviewID = 5, MedicalSpecialtyID = 15,  UserGroupID = 0, DiagnosticFactorID = 5
                },
                new RequiredSystemReview {
                    RequiredSystemReviewID = 6, MedicalSpecialtyID = 15,  UserGroupID = 0, DiagnosticFactorID = 6
                },
                new RequiredSystemReview {
                    RequiredSystemReviewID = 7, MedicalSpecialtyID = 15,  UserGroupID = 0, DiagnosticFactorID = 7
                },
                new RequiredSystemReview {
                    RequiredSystemReviewID = 8, MedicalSpecialtyID = 15,  UserGroupID = 0, DiagnosticFactorID = 8
                },
                new RequiredSystemReview {
                    RequiredSystemReviewID = 9, MedicalSpecialtyID = 15,  UserGroupID = 0, DiagnosticFactorID = 9
                },
                new RequiredSystemReview {
                    RequiredSystemReviewID = 10, MedicalSpecialtyID = 15,  UserGroupID = 0, DiagnosticFactorID = 10
                }
            };
            RequiredSystemReviews.ForEach(s => context.RequiredSystemReviews.Add(s));
            context.SaveChanges();

            //
            var PatientSystemReviews = new List<PatientSystemReview>() {
                new PatientSystemReview {
                    PatientSystemReviewID = 1,
                    PatientProfileID = 1,
                    RequiredSystemReviewID = 3,
                    PatientNote = ""
                },
                new PatientSystemReview {
                    PatientSystemReviewID = 2,
                    PatientProfileID = 1,
                    RequiredSystemReviewID = 7,
                    PatientNote = ""
                },
                new PatientSystemReview {
                    PatientSystemReviewID = 3,
                    PatientProfileID = 2,
                    RequiredSystemReviewID = 7,
                    PatientNote = ""
                }
            };
            PatientSystemReviews.ForEach(s => context.PatientSystemReviews.Add(s));
            context.SaveChanges();
            //
            var PatientMedicalRecords = new List<PatientMedicalRecord>(){
                new PatientMedicalRecord {
                    PatientMedicalRecordID = 1,
                    PatientProfileID = 1, 
                    RequiredMedicalRecordID = 2,
                    DateReceived = DateTime.Parse("2006-02-16"),
                    HospitalReceived = "Columbus Grand Hospital",
                    PatientNotes = "Doctor wanted to confirm if blood vessels in the brain had been plugged",
                    FileName = "mri_example.jpg",
                    FileType = "jpg",
                    FileLocation = "App_Data/uploads/Originals",
                    IsUploadedByUser = true,
                    UploadDate = DateTime.Parse("2014-04-16"),
                    InternalCode = ""
                },
                new PatientMedicalRecord {
                    PatientMedicalRecordID = 2,
                    PatientProfileID = 2, 
                    RequiredMedicalRecordID = 3,
                    DateReceived = DateTime.Parse("2009-06-06"),
                    HospitalReceived = "Columbus Grand Hospital",
                    PatientNotes = "Doctor wanted to confirm if blood vessels in the brain had been plugged",
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
            var RequiredFamilyDiseaseHistories = new List<RequiredFamilyDiseaseHistory>()
            { 
               new RequiredFamilyDiseaseHistory {
                   RequiredFamilyDiseaseHistoryID = 1, MedicalSpecialtyID = 15, UserGroupID = 0, DiseaseID = 14
               },
               new RequiredFamilyDiseaseHistory {
                   RequiredFamilyDiseaseHistoryID = 2, MedicalSpecialtyID = 15, UserGroupID = 0, DiseaseID = 15
               },
               new RequiredFamilyDiseaseHistory {
                   RequiredFamilyDiseaseHistoryID = 3, MedicalSpecialtyID = 15, UserGroupID = 0, DiseaseID = 16
               },
               new RequiredFamilyDiseaseHistory {
                   RequiredFamilyDiseaseHistoryID = 4, MedicalSpecialtyID = 15, UserGroupID = 0, DiseaseID = 17
               },
                new RequiredFamilyDiseaseHistory {
                   RequiredFamilyDiseaseHistoryID = 5, MedicalSpecialtyID = 15, UserGroupID = 0, DiseaseID = 18
               },
               new RequiredFamilyDiseaseHistory {
                   RequiredFamilyDiseaseHistoryID = 6, MedicalSpecialtyID = 15, UserGroupID = 0, DiseaseID = 19
               },
               new RequiredFamilyDiseaseHistory {
                   RequiredFamilyDiseaseHistoryID = 7, MedicalSpecialtyID = 15, UserGroupID = 0, DiseaseID = 20
              }
           };
           RequiredFamilyDiseaseHistories.ForEach(s => context.RequiredFamilyDiseaseHistories.Add(s));
           context.SaveChanges();
            //
            var PatientFamilyDiseaseHistories = new List<PatientFamilyDiseaseHistory>()
            {
                new PatientFamilyDiseaseHistory {
                    PatientFamilyDiseaseHistoryID = 1,
                    PatientProfileID = 1,
                    RequiredFamilyDiseaseHistoryID = 1,
                    FamilyMember = FamilyMember.Father,
                    PatientNote = ""
                },
                new PatientFamilyDiseaseHistory {
                    PatientFamilyDiseaseHistoryID = 2,
                    PatientProfileID = 1,
                    RequiredFamilyDiseaseHistoryID = 2,
                    FamilyMember = FamilyMember.Father,
                    PatientNote = ""
                },
                new PatientFamilyDiseaseHistory {
                    PatientFamilyDiseaseHistoryID = 3,
                    PatientProfileID = 1,
                    RequiredFamilyDiseaseHistoryID = 2,
                    FamilyMember = FamilyMember.Grandparents,
                    PatientNote = ""
                },
                new PatientFamilyDiseaseHistory {
                    PatientFamilyDiseaseHistoryID = 4,
                    PatientProfileID = 2,
                    RequiredFamilyDiseaseHistoryID = 2,
                    FamilyMember = FamilyMember.Father,
                    PatientNote = ""
                },
                new PatientFamilyDiseaseHistory {
                    PatientFamilyDiseaseHistoryID = 5,
                    PatientProfileID = 2,
                    RequiredFamilyDiseaseHistoryID = 2,
                    FamilyMember = FamilyMember.Sister,
                    PatientNote = ""
                }
            };
            PatientFamilyDiseaseHistories.ForEach(s => context.PatientFamilyDiseaseHistories.Add(s));
            context.SaveChanges();
            //
            var PatientSubstanceUses = new List<PatientSubstanceUse>()
            {
                new PatientSubstanceUse {
                    PatientSubstanceUseID = 10,
                    Substance = Substance.Tabacco,
                    IsCurrentInUse = true,
                    IsPastInUse = false,
                    Quantity = "half pack a day",
                    LengthInYear = 15,
                    StoppedInYear = 0,
                }

            };
            PatientSubstanceUses.ForEach(s => context.PatientSubstanceUses.Add(s));
            context.SaveChanges();
            //
            var PatientSocialHistories = new List<PatientSocialHistory>()
            {
                new PatientSocialHistory {
                    PatientSocialHistoryID = 100,
                    PatientProfileID = 1,
                    SubstanceUses = new List<PatientSubstanceUse>(),
                    MaritalStatus = MaritalStatus.Married,
                    EmploymentStatus = EmploymentStatus.Retired,
                    ExerciseLevel = ExerciseLevel.Sedentary,
                    CurrentJob = "",
                    WasMentallyAbused = false,
                    WasPhysicallyAbused  = false,
                    IsDisabled = false
                },
                new PatientSocialHistory {
                    PatientSocialHistoryID = 101,
                    PatientProfileID = 2,
                    SubstanceUses = new List<PatientSubstanceUse>(),
                    MaritalStatus = MaritalStatus.Married,
                    EmploymentStatus = EmploymentStatus.Selfemployed,
                    ExerciseLevel = ExerciseLevel.Sedentary,
                    CurrentJob = "",
                    WasMentallyAbused = false,
                    WasPhysicallyAbused  = false,
                    IsDisabled = false
                }
            };
            PatientSocialHistories.ForEach(s => context.PatientSocialHistories.Add(s));
            context.SaveChanges();

            PatientSocialHistories[0].SubstanceUses.Add(PatientSubstanceUses[0]);
            context.SaveChanges();
            //
            PatientSocialHistories[1].SubstanceUses.Add(PatientSubstanceUses[0]);
            context.SaveChanges();
            //
            //var AntigenTypes = new List<AntigenType>()
            //{
            //    new Antigen {
            //        AntigenID = 1,
            //        Name = "Food",
            //        Desc = "Egg etc."
            //    },
            //    new Antigen {
            //        AntigenID = 2,
            //        Name = "Grass",
            //        Desc = "More severe in spring"
            //    },
            //    new Antigen{
            //        AntigenID = 3,
            //        Name = "Animal",
            //        Desc = "allergy when playing with my cat"
            //    }
            //};
            //Antigens.ForEach(s => context.Antigens.Add(s));
            //context.SaveChanges();
            //
            //var AllergyReactions = new List<AllergyReaction>()
            //{
            //    new AllergyReaction {
            //        AllergyReactionID = 1,
            //        AntigenID = 1,
            //        Reaction = "sneesing and caugh",
            //        IsPatientDescribed = true
            //    },
            //    new AllergyReaction {
            //        AllergyReactionID = 2,
            //        AntigenID = 3,
            //        Reaction = "skin becomes red and swelling",
            //        IsPatientDescribed = true,
            //    }
            //};
            //AllergyReactions.ForEach(s => context.AllergyReactions.Add(s));
            //context.SaveChanges();
            //
            //
            //var PatientAllergyHistories = new List<PatientAllergyHistory>()
            //{
            //    new PatientAllergyHistory {
            //        PatientAllergyHistoryID = 1,
            //        PatientProfileID = 2,
            //        AntigenName = "Asprin",
            //        IsMedicine = true,
            //        Reaction = "skin rash all over the body",
            //        YearDiscovered = 2012
            //    },
            //    new PatientAllergyHistory {
            //        PatientAllergyHistoryID = 2,
            //        PatientProfileID = 2,
            //        AntigenName = "cat",
            //        IsMedicine = false,
            //        Reaction = "sneesing and caugh",
            //        YearDiscovered = 2003
            //    }
            //};
            //PatientAllergyHistories.ForEach(s => context.PatientAllergyHistories.Add(s));
            //context.SaveChanges();
       
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
            //var RequiredDrugHistories = new List<RequiredDrugHistory>()
            //{
            //    new RequiredDrugHistory {
            //        RequiredDrugHistoryID = 1,
            //        MedicalSpecialtyID = 15,
            //        UserGroupID = 0,
            //        DrugID = 1
            //    },
            //    new RequiredDrugHistory {
            //        RequiredDrugHistoryID = 2,
            //        MedicalSpecialtyID = 15,
            //        UserGroupID = 0,
            //        DrugID = 3
            //    },
            //    new RequiredDrugHistory {
            //        RequiredDrugHistoryID = 3,
            //        MedicalSpecialtyID = 15,
            //        UserGroupID = 0,
            //        DrugID = 4
            //    },
            //    new RequiredDrugHistory {
            //        RequiredDrugHistoryID = 4,
            //        MedicalSpecialtyID = 15,
            //        UserGroupID = 0,
            //        DrugID = 5
            //    },
            //    new RequiredDrugHistory {
            //        RequiredDrugHistoryID = 5,
            //        MedicalSpecialtyID = 15,
            //        UserGroupID = 0,
            //        DrugID = 6
            //    },
            //    new RequiredDrugHistory {
            //        RequiredDrugHistoryID = 6,
            //        MedicalSpecialtyID = 15,
            //        UserGroupID = 0,
            //        DrugID = 7
            //    }
            //};
            //RequiredDrugHistories.ForEach(s => context.RequiredDrugHistories.Add(s));
            //context.SaveChanges();
            //

            //
            //******************************************************************************
            // TreatmentFactor
            // Note: for factors to clarify a particular disease, build the concerns into 
            // the lookup of the disease, eg Orginal NSCLC and Recurrent NSCLC
            //******************************************************************************
            var TreatmentFactors = new List<TreatmentFactor>()
            {
                new TreatmentFactor {
                    TreatmentFactorID = 1,
                    FactorName = "NSCLC clinical stage",
                    FactorCategory = TreatmentFactorCategory.DiseaseDynamicState,
                    //IsFromPatientPerspective = false,
                    AllowMultipleValues = false,
                    PatientPrompt = "Please indicate the stage of the cancer. If the stage has been redefined based on the findings from surgery, use the redefined stage.",
                    
                },
                new TreatmentFactor {
                    TreatmentFactorID = 2,
                    FactorName = "NSCLC stage I central or peripheral location",
                    FactorCategory = TreatmentFactorCategory.DiseaseDynamicState,
                    //IsFromPatientPerspective = false,
                    AllowMultipleValues = false,
                    PatientPrompt = "For stage I, based on the CT of the chest, where is the cancer located in the lung?",

                },
                new TreatmentFactor {
                    TreatmentFactorID = 3,
                    FactorName = "Lung cancer involvement of mediastinal lymph node for stage I and II",
                    FactorCategory = TreatmentFactorCategory.DiseaseDynamicState,
                    //IsFromPatientPerspective = false,
                    AllowMultipleValues = false,
                    PatientPrompt = "Does the cancer spread to the mediastinal lymph node?",

                },
                new TreatmentFactor {
                    TreatmentFactorID = 4,
                    FactorName = "Medical feasibility for major surgery",
                    FactorCategory = TreatmentFactorCategory.PatientFeasibility,
                    //IsFromPatientPerspective = true,
                    AllowMultipleValues = false,
                    PatientPrompt = "Can patient's gneneral heath tolerate a major surgery?",

                },
        
                new TreatmentFactor {
                    TreatmentFactorID = 5,
                    FactorName = "Surgical margin",
                    FactorCategory = TreatmentFactorCategory.PostTreatmentEvaluation,
                    //IsFromPatientPerspective = false,
                    AllowMultipleValues = false,
                    PatientPrompt = "If the cancer has been removed through sugery, Is the sugical margin positive for cancer?",

                },
                new TreatmentFactor {
                    TreatmentFactorID = 6,
                    FactorName = "NSCLC T3 invasion or T4 extension for IIB, IIIA, IIIB",
                    FactorCategory = TreatmentFactorCategory.DiseaseDynamicState,
                    //IsFromPatientPerspective = false,
                    AllowMultipleValues = false,
                    PatientPrompt = "Does cancer invade the following part?",

                },
                new TreatmentFactor {
                    TreatmentFactorID = 7,
                    FactorName = "Resectability",
                    FactorCategory = TreatmentFactorCategory.TreatmentFeasibility,
                    //IsFromPatientPerspective = false,
                    AllowMultipleValues = false,
                    PatientPrompt = "What option below meets patient's situation regarding the resectabilty of the cancer?",

                },
                new TreatmentFactor {
                    TreatmentFactorID = 8,
                    FactorName = "NSCLC mediastinal biopsy if IIIA, IIIB",
                    FactorCategory = TreatmentFactorCategory.DiseaseDynamicState,
                    //IsFromPatientPerspective = false,
                    AllowMultipleValues = false,
                    PatientPrompt = "If a mediastinal biopsy is done, which statement below best reflect the findings?",

                },
       
                new TreatmentFactor {
                    TreatmentFactorID = 9,
                    FactorName = "NSCLC separate nodules if IIB, IIIA, IV",
                    FactorCategory = TreatmentFactorCategory.DiseaseDynamicState,
                    //IsFromPatientPerspective = false,
                    AllowMultipleValues = false,
                    PatientPrompt = "If the cacner presents as separate nodules in the lungs, what is the number and location of the nodule(s)?",
          
                },
                new TreatmentFactor {
                    TreatmentFactorID = 10,
                    FactorName = "NSCLC stage IV solitary or false-pleural metastasis",
                    FactorCategory = TreatmentFactorCategory.DiseaseDynamicState,
                    //IsFromPatientPerspective = false,
                    AllowMultipleValues = false,
                    PatientPrompt = "If the tumor has spread to remote site, does any of the following situation exist?",
       
                },

                new TreatmentFactor {
                    TreatmentFactorID = 11,
                    FactorName = "Lung cancer symptom palliation",
                    FactorCategory = TreatmentFactorCategory.OtherSupport,
                    //IsFromPatientPerspective = true,
                    AllowMultipleValues = true,
                    PatientPrompt = "Indicate what symptom(s) below the patient are experiencing?",
    
                },
                new TreatmentFactor {
                    TreatmentFactorID = 12,
                    FactorName = "NSCLC cell types",
                    FactorCategory = TreatmentFactorCategory.DiseaseStaticState,
                    //IsFromPatientPerspective = false,
                    AllowMultipleValues = false,
                    PatientPrompt = "What type of cells the cancer orginates?",
         
                },
                new TreatmentFactor {
                    TreatmentFactorID = 13,
                    FactorName = "EGFR mutation testing",
                    FactorCategory = TreatmentFactorCategory.DiseaseStaticState,
                    //IsFromPatientPerspective = false,
                    AllowMultipleValues = false,
                    PatientPrompt = "If patient has had a EGFR mutation test, what is the result?",
     
                },
                 new TreatmentFactor {
                    TreatmentFactorID = 14,
                    FactorName = "ALK testing",
                    FactorCategory = TreatmentFactorCategory.DiseaseStaticState,
                    //IsFromPatientPerspective = true,
                    AllowMultipleValues = false,
                    PatientPrompt = "If patient has had a ALK test, what is the result?",
     
                },
                new TreatmentFactor {
                    TreatmentFactorID = 15,
                    FactorName = "Patient physical performance",
                    FactorCategory = TreatmentFactorCategory.PatientFeasibility,
                    //IsFromPatientPerspective = true,
                    AllowMultipleValues = false,
                    PatientPrompt = "What of the below situation best describe patient's physical performace?",
   
                },
                new TreatmentFactor {
                    TreatmentFactorID = 16,
                    FactorName = "Recurrence",
                    FactorCategory = TreatmentFactorCategory.DiseaseDynamicState,
                    //IsFromPatientPerspective = true,
                    AllowMultipleValues = false,
                    PatientPrompt = "Is this an original occurence or a recurrence?",
         
                },
                new TreatmentFactor {
                    TreatmentFactorID = 17,
                    FactorName = "NSCLC location of recurrence",
                    FactorCategory = TreatmentFactorCategory.DiseaseDynamicState,
                    //IsFromPatientPerspective = true,
                    AllowMultipleValues = false,
                    PatientPrompt = "What recurrence below best describe patient's condition?",
                 },
            };
            TreatmentFactors.ForEach(s => context.TreatmentFactors.Add(s));
            context.SaveChanges();
            //
            var TreatmentConditions = new List<TreatmentCondition>()
            {
                new TreatmentCondition {
                    TreatmentConditionID = 1,  //Clinical stage for NSCLC
                    TreatmentFactorID = 1,
                    FactorValue = "IA",
                    Order = 1,
                    IsComposed = false,
                    Note = ""
                },
                 new TreatmentCondition {
                    TreatmentConditionID = 2,  //Clinical stage for NSCLC
                    TreatmentFactorID = 1,
                    FactorValue = "IB",
                    Order = 2,
                    IsComposed = false,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 3,  //Clinical stage for NSCLC
                    TreatmentFactorID = 1,
                    FactorValue = "IIA",
                    Order = 3,
                    IsComposed = false,
                    Note = ""
                },
                 new TreatmentCondition {
                    TreatmentConditionID = 4,  //Clinical stage for NSCLC
                    TreatmentFactorID = 1,
                    FactorValue = "IIB",
                    Order = 4,
                    IsComposed = false,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 5,  //Clinical stage for NSCLC
                    TreatmentFactorID = 1,
                    FactorValue = "IIIA",
                    Order = 5,
                    IsComposed = false,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 6,  //Clinical stage for NSCLC
                    TreatmentFactorID = 1,
                    FactorValue = "IIIB",
                    Order = 6,
                    IsComposed = false,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 7,  //Clinical stage IV for NSCLC
                    TreatmentFactorID = 1,
                    FactorValue = "IV",
                    Order = 7,
                    IsComposed = false,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 8,  //Central or peropheral for Stage I
                    TreatmentFactorID = 2,
                    FactorValue = "Peripheral",
                    Order = 1,
                    IsComposed = false,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 9,  //Central or peropheral for Stage I
                    TreatmentFactorID = 2,
                    FactorValue = "Central",
                    Order = 2,
                    IsComposed = false,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 10,  //Central or peropheral for Stage I
                    TreatmentFactorID = 2,
                    FactorValue = "Not applicable",
                    Order = 3,
                    IsComposed = false,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 11,  //Central or peropheral for Stage I
                    TreatmentFactorID = 2,
                    FactorValue = "I don't know",
                    Order = 4,
                    IsComposed = false,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 12,  //involvemen of mediastinal lymph node
                    TreatmentFactorID = 3,
                    FactorValue = "Negative",
                    Order = 1,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 13,  //involvemen of mediastinal lymph node
                    TreatmentFactorID = 3,
                    FactorValue = "Positive",
                    Order = 2,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 14,  //involvemen of mediastinal lymph node
                    TreatmentFactorID = 3,
                    FactorValue = "I don't know",
                    Order = 3,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 15,  //medical feasibility for major surgery
                    TreatmentFactorID = 4,
                    FactorValue = "Tolerable",
                    Order = 1,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 16,  //medical feasibility for major surgery
                    TreatmentFactorID = 4,
                    FactorValue = "Not tolerable",
                    Order = 2,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 17,  //medical feasibility for major surgery
                    TreatmentFactorID = 4,
                    FactorValue = "I don't know",
                    Order = 3,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 18,  //surgical margin
                    TreatmentFactorID = 5,
                    FactorValue = "Surgical margin positive wih cancer cells",
                    Order = 1,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 19,  //surgical margin
                    TreatmentFactorID = 5,
                    FactorValue = "Surgical margin negative wih cancer cells",
                    Order = 2,
                    Note = ""
                },
                 new TreatmentCondition {
                    TreatmentConditionID = 20,  //surgical margin
                    TreatmentFactorID = 5,
                    FactorValue = "I don't know",
                    Order = 3,
                    Note = ""
                },
                 new TreatmentCondition {
                    TreatmentConditionID = 21,  //surgical margin
                    TreatmentFactorID = 5,
                    FactorValue = "Not applicable",
                    Order = 4,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 22,  //IIa or IIIb local extension
                    TreatmentFactorID = 6,
                    FactorValue = "Superior sulcus",
                    Order = 1,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 23,  //IIa or IIIb local extension
                    TreatmentFactorID = 6,
                    FactorValue = "Chest wall",
                    Order = 2,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 24,  //IIa or IIIb local extension
                    TreatmentFactorID = 6,
                    FactorValue = "Proximation airway or mediastinum ",
                    Order = 3,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 25,  //IIa or IIIb local extension
                    TreatmentFactorID = 6,
                    FactorValue = "None of the above ",
                    Order = 4,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 26,  //IIa or IIIb local extension
                    TreatmentFactorID = 6,
                    FactorValue = "I don't know",
                    Order = 5,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 27,  //Resectability
                    TreatmentFactorID = 7,
                    FactorValue = "Can be removed completely",
                    Order = 1,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 28,  //Resectability
                    TreatmentFactorID = 7,
                    FactorValue = "Can not be removed completely",
                    Order = 2,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 29,  //Resectability
                    TreatmentFactorID = 7,
                    FactorValue = "I don't know",
                    Order = 3,
                    Note = ""
                },
              
                new TreatmentCondition {
                    TreatmentConditionID = 30,  //Findings from mediastinal biopsy
                    TreatmentFactorID = 8,
                    FactorValue = "N2 positive",
                    Order = 1,
                    Note = "The cancer has spread to subcarinal lymph nodes (around the point where the windpipe branches into the left adn right bronchi) or lymph nodes in the mediastinum. Affected lymph node on the same side of the cancerous lung."
                },
                new TreatmentCondition {
                    TreatmentConditionID = 31,  //Findings from mediastinal biopsy
                    TreatmentFactorID = 8,
                    FactorValue = "N3 positive",
                    Order = 2,
                    Note = "The cancer has spread to lymph nodes near the collarbone on either side, and/or to jilar or mediastinal lymph nodes on the side opposite the lung with tumor."
                },
                new TreatmentCondition {
                    TreatmentConditionID = 32,  //Findings from mediastinal biopsy
                    TreatmentFactorID = 8,
                    FactorValue = "Both N2 and N3 negative",
                    Order = 3,
                    Note = ""
                },
                 new TreatmentCondition {
                    TreatmentConditionID = 33,  //Findings from mediastinal biopsy
                    TreatmentFactorID = 8,
                    FactorValue = "I don't know",
                    Order = 4,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 34,  //Intrathoracic metastasis
                    TreatmentFactorID = 9,
                    FactorValue = "Separate pulmonary nodule(s) in the same lobe as the primary site",
                    Order = 1,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 35,  //Intrathoracic metastasis
                    TreatmentFactorID = 9,
                    FactorValue = "Separate pulmonary nodule(s) in the differnt lobe but same side of lung as the primary site",
                    Order = 2,
                    Note = ""
                },
                 new TreatmentCondition {
                    TreatmentConditionID = 36,  //Intrathoracic metastasis
                    TreatmentFactorID = 9,
                    FactorValue = "None of the above situations",
                    Order = 3,
                    Note = ""
                },
                //
                new TreatmentCondition {
                    TreatmentConditionID = 37,  //Intrathoracic metastasis
                    TreatmentFactorID = 10,
                    FactorValue = "Separate soliatary pulmonary nodule in the contralateral side of lung as the primary site",
                    Order = 3,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 38,  //Extrathoracic
                    TreatmentFactorID = 10,
                    FactorValue = "Brain solitary site",
                    Order = 2,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 39,  //Extrathoracic
                    TreatmentFactorID = 10,
                    FactorValue = "Adrenal solitary site",
                    Order = 3,
                    Note = ""
                },
                 new TreatmentCondition {
                    TreatmentConditionID = 40,  //Extrathoracic
                    TreatmentFactorID = 10,
                    FactorValue = "Other solitary site",
                    Order = 4,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 41,  //Extrathoracic
                    TreatmentFactorID = 10,
                    FactorValue = "Pleural or pericardinal effusion",
                    Order = 1,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 42,  //Extrathoracic
                    TreatmentFactorID = 10,
                    FactorValue = "Remote site, diseminated",
                    Order = 5,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 43,  //Extrathoracic
                    TreatmentFactorID = 10,
                    FactorValue = "I don't know",
                    Order = 6,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 44,  //localized symptoms of lung cancer
                    TreatmentFactorID = 11,
                    FactorValue = "Symptoms of endobronchial obstruction",
                    Order = 1,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 45,  //localized symptoms of lung cancer
                    TreatmentFactorID = 11,
                    FactorValue = "Symptoms of superior vena cava obstruction",
                    Order = 2,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 46,  //localized symptoms of lung cancer
                    TreatmentFactorID = 11,
                    FactorValue = "Severe hemoptysis",
                    Order = 3,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 47,  //localized symptoms of lung cancer
                    TreatmentFactorID = 11,
                    FactorValue = "Bone metatasis",
                    Order = 4,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 48,  //localized symptoms of lung cancer
                    TreatmentFactorID = 11,
                    FactorValue = "difficulty breathing caused by tumor obstruction",
                    Order = 4,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 49,  //localized symptoms of lung cancer
                    TreatmentFactorID = 11,
                    FactorValue = "None of the above situation",
                    Order = 4,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 50,  //Cell types of NSCLC
                    TreatmentFactorID = 12,
                    FactorValue = "Adenocarcinoma",
                    Order = 1,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 51,  //Cell types of NSCLC
                    TreatmentFactorID = 12,
                    FactorValue = "Large cell",
                    Order = 2,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 52,  //Cell types of NSCLC
                    TreatmentFactorID = 12,
                    FactorValue = "Squamous cell",
                    Order = 3,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 53,  //Cell types of NSCLC
                    TreatmentFactorID = 12,
                    FactorValue = "Not Specified (NOS)",
                    Order = 4,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 54,  //Cell types of NSCLC
                    TreatmentFactorID = 12,
                    FactorValue = "I don't know",
                    Order = 5,
                    Note = ""
                },
                 new TreatmentCondition {
                    TreatmentConditionID = 55,  //EGFR testing
                    TreatmentFactorID = 13,
                    FactorValue = "EGFR mutation positive",
                    Order = 1,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 56,  //EGFR testing
                    TreatmentFactorID = 13,
                    FactorValue = "EGFR mutation negative",
                    Order = 2,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 57,  //EGFR testing
                    TreatmentFactorID = 13,
                    FactorValue = "Not done",
                    Order = 3,
                    Note = ""
                },
                 new TreatmentCondition {
                    TreatmentConditionID = 58,  //EGFR testing
                    TreatmentFactorID = 13,
                    FactorValue = "I don't know",
                    Order = 4,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 59,  //ALK testing
                    TreatmentFactorID = 14,
                    FactorValue = "ALK positive",
                    Order = 1,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 60,  //ALK testing
                    TreatmentFactorID = 14,
                    FactorValue = "ALK nagative",
                    Order = 2,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 61,  //ALK testing
                    TreatmentFactorID = 14,
                    FactorValue = "Not done the test",
                    Order = 3,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 62,  //ALK testing
                    TreatmentFactorID = 14,
                    FactorValue = "I don't know",
                    Order = 4,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 63,  //ECOG Physical performance
                    TreatmentFactorID = 15,
                    FactorValue = "Asymptomatic",
                    Order = 1,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 64,  //ECOG Physical performance
                    TreatmentFactorID = 15,
                    FactorValue = "Symptomatic, fully ambulatory",
                    Order = 2,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 65,  //ECOG Physical performance
                    TreatmentFactorID = 15,
                    FactorValue = "Symptomatic, in bed less than 50% of the day",
                    Order = 3,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 66,  //ECOG Physical performance
                    TreatmentFactorID = 15,
                    FactorValue = "Symptomatic, in bed more than 50% of the day, but not bedridden",
                    Order = 4,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 67,  //ECOG Physical performance
                    TreatmentFactorID = 15,
                    FactorValue = "Bedridden",
                    Order = 5,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 68,  //Recurrence
                    TreatmentFactorID = 16,
                    FactorValue = "New onset",
                    Order = 1,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 69,  //Recurrence
                    TreatmentFactorID = 16,
                    FactorValue = "Recurrence",
                    Order = 2,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 70,  //NSCLC Recurrence
                    TreatmentFactorID = 17,
                    FactorValue = "Local regional",
                    Order = 1,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 71,  //NSCLC Recurrence
                    TreatmentFactorID = 17,
                    FactorValue = "Mediastinal lymph node",
                    Order = 2,
                    Note = ""
                },
                 new TreatmentCondition {
                    TreatmentConditionID = 72,  //NSCLC Recurrence
                    TreatmentFactorID = 17,
                    FactorValue = "Remote site",
                    Order = 3,
                    Note = ""
                },
                //*********************************************
                //for composed conditions
                //*********************************************
                new TreatmentCondition {
                    TreatmentConditionID = 73,  
                    TreatmentFactorID = 1,
                    FactorValue = "2,3,4",  //I+centtral??, IB, IIA, IIB
                    Order = 0,
                    IsComposed = true,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 74,  
                    TreatmentFactorID = 1,
                    FactorValue = "4,5",  //IIB or IIIA
                    Order = 0,
                    IsComposed = true,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 75,  
                    TreatmentFactorID = 9,
                    FactorValue = "34,35",    //separate node in the same lobe or different lobe but same side
                    Order = 0,
                    IsComposed = true,
                    Note = ""
                },
                 new TreatmentCondition {
                    TreatmentConditionID = 76,  
                    TreatmentFactorID = 12,
                    FactorValue = "50,51",    //Adenocarcinoma or large cell
                    Order = 0,
                    IsComposed = true,
                    Note = ""
                },
                new TreatmentCondition {
                    TreatmentConditionID = 77,  
                    TreatmentFactorID = 15,
                    FactorValue = "63,64",    //PS0 or PS1
                    Order = 0,
                    IsComposed = true,
                    Note = ""
                },


            };
            TreatmentConditions.ForEach(s => context.TreatmentConditions.Add(s));
            context.SaveChanges();
            //
            var TreatmentPlans = new List<TreatmentPlan>(){
                //Observe
                new TreatmentPlan { TreatmentPlanID = 1, Name = "Observe", Desc = "" },
                //start with surgery
                new TreatmentPlan { TreatmentPlanID = 2, Name = "Surgery", Desc = "" },
                new TreatmentPlan { TreatmentPlanID = 3, Name = "Surgical resection", Desc = "",  },
                new TreatmentPlan { TreatmentPlanID = 4, Name = "Sugical resection and mediastinal lymph node dissection or systematic lymph node sampling", Desc = "",},
                new TreatmentPlan { TreatmentPlanID = 5, Name = "Sugical resection followed with chemotherapy",  Desc = "", },
                //start with chemotherapy
                new TreatmentPlan { TreatmentPlanID = 6, Name = "Chemotherapy", Desc = "",  },
                new TreatmentPlan { TreatmentPlanID = 7, Name = "Chemotherapy followed with surgical resection",  Desc = "",  },
                new TreatmentPlan { TreatmentPlanID = 8, Name = "Induction chemotherapy followed with progression evaluation", Desc = "", },
                new TreatmentPlan { TreatmentPlanID = 9, Name = "Induction chemotherapy plus radiation followed with progression evaluation", Desc = "",  },
                //start with radiation
                new TreatmentPlan { TreatmentPlanID = 10, Name = "Radiation", Desc = "",  },
                new TreatmentPlan { TreatmentPlanID = 11, Name = "Radiation followed with chemotherapy", Desc = "",  },
                new TreatmentPlan { TreatmentPlanID = 12, Name = "Definitive radiation", Desc = "",},
                new TreatmentPlan { TreatmentPlanID = 13, Name = "Definitive radiation followed with chemotherapy", Desc = "", },
                new TreatmentPlan { TreatmentPlanID = 14, Name = "SABR", Desc = "", },
                new TreatmentPlan { TreatmentPlanID = 15, Name = "SABR followed with chemotherapy", Desc = "", },
                //start with chemoradiation
                new TreatmentPlan { TreatmentPlanID = 16, Name = "Concurrent chemoradiation", Desc = "", },
                new TreatmentPlan { TreatmentPlanID = 17, Name = "Concurrent chemoradiation followed with surgical resection", Desc = "", },
                new TreatmentPlan { TreatmentPlanID = 18, Name = "Concurrent chemoradiation followed with chemotherapy", Desc = "",  },
                new TreatmentPlan { TreatmentPlanID = 19, Name = "Concurrent chemoradiation followed with surgical reevaluation", Desc = "",  },
                new TreatmentPlan { TreatmentPlanID = 20, Name = "Concurrent chemoradiation, followed with surgery, then with chemotherapy", Desc = "", },
                new TreatmentPlan { TreatmentPlanID = 21, Name = "Definitive concurrent chemoradiation", Desc = "", },
                new TreatmentPlan { TreatmentPlanID = 22, Name = "Definitive concurrent chemoradiation followed with chemotherapy", Desc = "",},
                //local - plureu
                new TreatmentPlan { TreatmentPlanID = 23, Name = "Pleurodesis", Desc = "", },
                new TreatmentPlan { TreatmentPlanID = 24, Name = "Ambulatory small catheter drainage", Desc = "",  },
                new TreatmentPlan { TreatmentPlanID = 25, Name = "Pericardinal window", Desc = "", },
                //local - brain
                new TreatmentPlan { TreatmentPlanID = 26, Name = "Surgical resection followed with WBRT", Desc = "",  },
                new TreatmentPlan { TreatmentPlanID = 27, Name = "Surgical resection followed with SRS", Desc = "", },
                new TreatmentPlan { TreatmentPlanID = 28, Name = "SRS plus WBRT", Desc = "", },
                new TreatmentPlan { TreatmentPlanID = 29, Name = "SRS alone", Desc = "",  },
                //
                new TreatmentPlan { TreatmentPlanID = 30, Name = "Surgerical resection for adrenal lesion", Desc = "",  },
                //
                new TreatmentPlan { TreatmentPlanID = 31, Name = "Laser therapy", Desc = "", },
                new TreatmentPlan { TreatmentPlanID = 32, Name = "Stent", Desc = "", },
                new TreatmentPlan { TreatmentPlanID = 33, Name = "Brachytherapy", Desc = "",  },
                new TreatmentPlan { TreatmentPlanID = 34, Name = "External-beam radiation therapy", Desc = "",  },
                new TreatmentPlan { TreatmentPlanID = 35, Name = "Photodynamic therapy", Desc = "",  },
                new TreatmentPlan { TreatmentPlanID = 36, Name = "Embolization", Desc = "",  },
               
                //
                new TreatmentPlan { TreatmentPlanID = 37, Name = "Palliative external-beam radiation therapy", Desc = "", },
                new TreatmentPlan { TreatmentPlanID = 38, Name = "Palliative external-beam radiation plus orthopedic stabilization", Desc = "", },
                //
                
                //single drug chemo
                new TreatmentPlan { TreatmentPlanID = 39, Name = "Eriotinib", Desc = "", },
                new TreatmentPlan { TreatmentPlanID = 40, Name = "Cetuximab", Desc = "", },
                new TreatmentPlan { TreatmentPlanID = 41, Name = "Docetaxel", Desc = "", },
                new TreatmentPlan { TreatmentPlanID = 42, Name = "Pemetrexed", Desc = "", },
                new TreatmentPlan { TreatmentPlanID = 43, Name = "Gemcitabine", Desc = "", },
                new TreatmentPlan { TreatmentPlanID = 44, Name = "Crizotinib", Desc = "",  },
                //
                //combined chemo
                new TreatmentPlan { TreatmentPlanID = 45, Name = "Doublet chemotherapy", Desc = "",  },
                new TreatmentPlan { TreatmentPlanID = 46, Name = "Platinum doublet plus bevacixumab", Desc = "",  },
                new TreatmentPlan { TreatmentPlanID = 47, Name = "Bevacizumab plus chemotherapy", Desc = "",  },
                new TreatmentPlan { TreatmentPlanID = 48, Name = "Cisplatin/pemetrexed", Desc = "",  },
                new TreatmentPlan { TreatmentPlanID = 49, Name = "Cetuximab/vinorelbine/cisplatin", Desc = "", },
                new TreatmentPlan { TreatmentPlanID = 50, Name = "Add Eriotinib to current chemotherapy", Desc = "",  },
                //
                //second-line therapy
                new TreatmentPlan { TreatmentPlanID = 51, Name = "Continuation of current regimen until disease progression", Desc = "", },
                new TreatmentPlan { TreatmentPlanID = 52, Name = "Continue maintenance bevacizumab", Desc = "",  },
                new TreatmentPlan { TreatmentPlanID = 53, Name = "Continue maintenance cetuximab", Desc = "", },
                new TreatmentPlan { TreatmentPlanID = 54, Name = "Continue maintenance gemcitabine", Desc = "",},
                //
                new TreatmentPlan { TreatmentPlanID = 55, Name = "Switch maintenance Eriotinib", Desc = "",  },
                new TreatmentPlan { TreatmentPlanID = 56, Name = "Switch maintenance pemetrexed", Desc = "", },
                new TreatmentPlan { TreatmentPlanID = 57, Name = "Switch maintenance docetaxel", Desc = "",  },
                //
                new TreatmentPlan { TreatmentPlanID = 58, Name = "Best supportive care", Desc = "",  },
            };
            TreatmentPlans.ForEach(s => context.TreatmentPlans.Add(s));
            context.SaveChanges();
            //
            var DiseaseTreatmentIndications = new List<DiseaseTreatmentIndication>(){
                //
                //mediastinal node negative
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 1, DiseaseID = 4, Indication = "IA, peripheal, N0, medically operable", Order = 1 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 2, DiseaseID = 4, Indication = "IA, peripheal, N0, medically inoperable", Order = 2 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 3, DiseaseID = 4, Indication = "IA central to IIB, N0, medically operable", Order = 3 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 4, DiseaseID = 4, Indication = "IA central to IIB, N0, medically inoperable", Order = 4 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 5, DiseaseID = 4, Indication = "IIA,IIB, N1, medically operable", Order = 5 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 6, DiseaseID = 4, Indication = "IIA,IIB, N1, medically inoperable", Order = 6 },
                //
                //after surgery exploration
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 7, DiseaseID = 4, Indication = "IA, peripheal, N0, margin negative", Order = 7 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 8, DiseaseID = 4, Indication = "IA, peripheal, N0, margin positive", Order = 8 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 9, DiseaseID = 4, Indication = "IB, IIA, N0, margin negative", Order = 9 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 10, DiseaseID = 4, Indication = "IB, IIA, N0, margin positive", Order = 10 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 11, DiseaseID = 4, Indication = "IIA, IIB, N1, margin negative", Order = 11 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 12, DiseaseID = 4, Indication = "IIA, IIB, N1, margin positive", Order = 12 },
                //
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 13, DiseaseID = 4, Indication = "IIB, IIIA, T3 or T4, No or N1, superior sucus, resectable", Order = 13 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 14, DiseaseID = 4, Indication = "IIB, IIIA, T3 or T4, No or N1, superior sucus, unrescatble", Order = 14 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 15, DiseaseID = 4, Indication = "IIB, IIIA, T3 or T4, No or N1, chest wall, or proximal airway or mediastinum", Order = 15 },
                //
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 16, DiseaseID = 4, Indication = "IIIA(T1-3, N0-1), N2N3 negative, resectable", Order = 16 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 17, DiseaseID = 4, Indication = "IIIA(T1-3, N0-1), N2N3 negative, unresectable", Order = 17 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 18, DiseaseID = 4, Indication = "IIIA(T1-3), N2 positive, nagative metastasis", Order = 18 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 19, DiseaseID = 4, Indication = "IIIA(T3 Invasion), N2 positive, nagative metastasis", Order = 19 },
                //
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 20, DiseaseID = 4, Indication = "IIB or IIIA, T3N0 or T4N0, separate nodule in ipsilateral lung, resectable", Order = 20 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 21, DiseaseID = 4, Indication = "IIB or IIIA, T3N0 or T4N0, separate nodule in ipsilateral lung, unresectable", Order = 21 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 22, DiseaseID = 4, Indication = "IV, contralateral solitary nodule", Order = 22 },
                //
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 23, DiseaseID = 4, Indication = "IIIB, T4, N2 (NSCL-10)", Order = 23 }, 
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 24, DiseaseID = 4, Indication = "IIIB, T4, N3 (NSCL-10)", Order = 24 },
                //
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 25, DiseaseID = 4, Indication = "IV, M1a, pleural or pericardial effusion, negative pleural or pericardial involvement", Order = 25 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 26, DiseaseID = 4, Indication = "IV, brain solitary site", Order = 26 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 27, DiseaseID = 4, Indication = "IV, adrenal solitary site", Order = 27 },
                //
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 28, DiseaseID = 4, Indication = "Any stage, Endobronchial obstruction", Order = 28 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 29, DiseaseID = 4, Indication = "Any stage, Superior vena cava obstruction", Order = 29 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 30, DiseaseID = 4, Indication = "Any stage, Severe hemoptysis", Order = 30 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 31, DiseaseID = 4, Indication = "IV, Diffuse brain metastasis", Order = 31 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 32, DiseaseID = 4, Indication = "IV, Bone metastasis", Order = 32 },
                //
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 33, DiseaseID = 4, Indication = "recurrence, locoreginal, resectable", Order = 33 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 34, DiseaseID = 4, Indication = "recurrence, mediastinal lymph node", Order = 34 },
                //
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 35, DiseaseID = 4, Indication = "IV diseminated, non-squamous, PS0", Order = 35 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 36, DiseaseID = 4, Indication = "IV diseminated, non-squamous, PS1", Order = 36 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 37, DiseaseID = 4, Indication = "IV diseminated, non-squamous, PS2", Order = 37 },
                //
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 38, DiseaseID = 4, Indication = "IV diseminated, non-squamous, positive EGFR mutation", Order = 38 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 39, DiseaseID = 4, Indication = "IV diseminated, non-squamous, positive ALK", Order = 39 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 40, DiseaseID = 4, Indication = "IV diseminated, squamous, PS0", Order = 40 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 41, DiseaseID = 4, Indication = "IV diseminated, squamous, PS1", Order = 41 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 42, DiseaseID = 4, Indication = "IV diseminated, squamous, PS2", Order = 42 },
                //
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 43, DiseaseID = 4, Indication = "IV diseminated, PS3", Order = 43 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 44, DiseaseID = 4, Indication = "IV diseminated, PS4", Order = 44 },
                //
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 45, DiseaseID = 4, Indication = "IV diseminated, non-squamous, progression upon first-line", Order = 45 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 46, DiseaseID = 4, Indication = "IV diseminated, non-squamous, response upon first-line" , Order = 46 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 47, DiseaseID = 4, Indication = "IV diseminated, squamous, progression upon first-line", Order = 47 },
                new DiseaseTreatmentIndication { 
                    DiseaseTreatmentIndicationID = 48, DiseaseID = 4, Indication = "IV diseminated, squamous, response upon first-line", Order = 48 },
            };
            DiseaseTreatmentIndications.ForEach(s => context.DiseaseTreatmentIndications.Add(s));
            context.SaveChanges();
            //
            var IndicatedTreatmentConditions = new List<IndicatedTreatmentCondition>()
            {
                //Name = "IA, peripheal, N0, medically operable"
                //IA
                new IndicatedTreatmentCondition {
                     IndicatedTreatmentConditionID = 1, DiseaseTreatmentIndicationID = 1, TreatmentConditionID = 1, Order = 1
                },
                //peripheral
                new IndicatedTreatmentCondition {
                     IndicatedTreatmentConditionID = 2, DiseaseTreatmentIndicationID = 1, TreatmentConditionID = 8, Order = 2
                },
                //mediastinal node negative
                new IndicatedTreatmentCondition {
                     IndicatedTreatmentConditionID = 3, DiseaseTreatmentIndicationID = 1, TreatmentConditionID = 12, Order = 3
                },
                //medical operable
                new IndicatedTreatmentCondition {
                     IndicatedTreatmentConditionID = 4, DiseaseTreatmentIndicationID = 1, TreatmentConditionID = 15, Order = 4
                },
                //Name = "IA, peripheal, N0, medically NOT operable"
                new IndicatedTreatmentCondition {
                     IndicatedTreatmentConditionID = 5, DiseaseTreatmentIndicationID = 2, TreatmentConditionID = 1, Order = 1
                },
                //peripheral
                new IndicatedTreatmentCondition {
                     IndicatedTreatmentConditionID = 6, DiseaseTreatmentIndicationID = 2, TreatmentConditionID = 8, Order = 2
                },
                //mediastinal node negative
                new IndicatedTreatmentCondition {
                     IndicatedTreatmentConditionID = 7, DiseaseTreatmentIndicationID = 2, TreatmentConditionID = 12, Order = 3
                },
                //medical operable
                new IndicatedTreatmentCondition {
                     IndicatedTreatmentConditionID = 8, DiseaseTreatmentIndicationID = 2, TreatmentConditionID = 16, Order = 4
                },


                //Indication 20 => IIB or IIIA (4 or 5), T3N0 or T4N0(34 or 35), separate nodule in ipsilateral lung, resectable -> 27)
                //IIB Or IIIA (3 or 4)
                new IndicatedTreatmentCondition {
                     IndicatedTreatmentConditionID = 9, DiseaseTreatmentIndicationID = 20, TreatmentConditionID = 74, Order = 1
                },
                //separate node in ipsilateral lung 
                new IndicatedTreatmentCondition {
                     IndicatedTreatmentConditionID = 10, DiseaseTreatmentIndicationID = 20, TreatmentConditionID = 75, Order = 2
                },
                //mediastinal node negative
                new IndicatedTreatmentCondition {
                     IndicatedTreatmentConditionID = 11, DiseaseTreatmentIndicationID = 20, TreatmentConditionID = 12, Order = 3
                },
                //tumor resectable
                new IndicatedTreatmentCondition {
                     IndicatedTreatmentConditionID = 12, DiseaseTreatmentIndicationID = 20, TreatmentConditionID = 27, Order = 4
                },
                //medical operable
                new IndicatedTreatmentCondition {
                     IndicatedTreatmentConditionID = 13, DiseaseTreatmentIndicationID = 20, TreatmentConditionID = 15, Order = 5
                },


                //Indication 20 => IIB or IIIA, T3N0 or T4N0, separate nodule in ipsilateral lung, NOT resectable
                new IndicatedTreatmentCondition {
                     IndicatedTreatmentConditionID = 14, DiseaseTreatmentIndicationID = 21, TreatmentConditionID = 74, Order = 1
                },
                //separate node in ipsilateral lung (21 or 22)
                new IndicatedTreatmentCondition {
                     IndicatedTreatmentConditionID = 15, DiseaseTreatmentIndicationID = 21, TreatmentConditionID = 75, Order = 2
                },
                //mediastinal node negative
                new IndicatedTreatmentCondition {
                     IndicatedTreatmentConditionID = 16, DiseaseTreatmentIndicationID = 21, TreatmentConditionID = 12, Order = 3
                },
                new IndicatedTreatmentCondition {
                     IndicatedTreatmentConditionID = 17, DiseaseTreatmentIndicationID = 21, TreatmentConditionID = 28, Order = 4
                },


                //
                //35  "IV diseminated, non-squamous, PS0" 
                //stage IV 
                new IndicatedTreatmentCondition {
                     IndicatedTreatmentConditionID = 18, DiseaseTreatmentIndicationID = 35, TreatmentConditionID = 7, Order = 1
                },

                //diseminated
                new IndicatedTreatmentCondition {
                     IndicatedTreatmentConditionID = 19, DiseaseTreatmentIndicationID = 35, TreatmentConditionID = 42, Order = 2
                },
                //composed: non-squamous
                new IndicatedTreatmentCondition {
                     IndicatedTreatmentConditionID = 20, DiseaseTreatmentIndicationID = 35, TreatmentConditionID = 76, Order = 3
                },
                //compoed: PS0 or PS1
                new IndicatedTreatmentCondition {
                     IndicatedTreatmentConditionID = 21, DiseaseTreatmentIndicationID = 35, TreatmentConditionID = 77, Order = 4
                },
                //EGFR negative
                new IndicatedTreatmentCondition {
                     IndicatedTreatmentConditionID = 22, DiseaseTreatmentIndicationID = 35, TreatmentConditionID = 56, Order = 5
                },
                //
                //
                //IV, diseminated, palliation 
                //stageIV
                new IndicatedTreatmentCondition {
                     IndicatedTreatmentConditionID = 23, DiseaseTreatmentIndicationID = 30, TreatmentConditionID = 7, Order = 1
                },
                //diseminated
                new IndicatedTreatmentCondition {
                     IndicatedTreatmentConditionID = 24, DiseaseTreatmentIndicationID = 30, TreatmentConditionID = 42, Order = 2
                },
                //hemoptysis
                new IndicatedTreatmentCondition {
                     IndicatedTreatmentConditionID = 25, DiseaseTreatmentIndicationID = 30, TreatmentConditionID = 47, Order = 3
                },
            };
            IndicatedTreatmentConditions.ForEach(s => context.IndicatedTreatmentConditions.Add(s));
            context.SaveChanges(); 
            //
            var DiseaseTreatmentPlans = new List<DiseaseTreatmentPlan>()
            {
                new DiseaseTreatmentPlan {
                    DiseaseTreatmentPlanID = 1, 
                    DiseaseTreatmentIndicationID = 1, 
                    TreatmentPlanID = 4,
                    TargetCondition = "Lung lesion",
                    TreatmentPlanPreferrence = 1, 
                    NCCNCategory = "2A"
                },
                new DiseaseTreatmentPlan {
                    DiseaseTreatmentPlanID = 2, 
                    DiseaseTreatmentIndicationID = 2, 
                    TreatmentPlanID = 12, 
                    TargetCondition = "Lung lesion", 
                    TreatmentPlanPreferrence = 1,
                    NCCNCategory = "2A"
                },
                new DiseaseTreatmentPlan {
                    DiseaseTreatmentPlanID = 3, 
                    DiseaseTreatmentIndicationID = 2, 
                    TreatmentPlanID = 14, 
                    TargetCondition = "Lung lesion", 
                    TreatmentPlanPreferrence = 2,
                    NCCNCategory = "2A"
                },
                new DiseaseTreatmentPlan {
                    DiseaseTreatmentPlanID = 4, 
                    DiseaseTreatmentIndicationID = 20, 
                    TreatmentPlanID = 3, 
                    TargetCondition = "Lung lesion", 
                    TreatmentPlanPreferrence = 1,
                    NCCNCategory = "2A"
                },
                new DiseaseTreatmentPlan {
                    DiseaseTreatmentPlanID = 5, 
                    DiseaseTreatmentIndicationID = 21, 
                    TreatmentPlanID = 18, 
                    TargetCondition = "Lung lesion", 
                    TreatmentPlanPreferrence = 1,
                    NCCNCategory = "2A"
                },
                //IV squamous PS0 or PS1
                new DiseaseTreatmentPlan {
                    DiseaseTreatmentPlanID = 6, 
                    DiseaseTreatmentIndicationID = 35, 
                    TreatmentPlanID = 6,  //need to update to systemic chemotherapy??
                    TargetCondition = "Lung lesion", 
                    TreatmentPlanPreferrence = 1,
                    NCCNCategory = "2A"
                },
                 new DiseaseTreatmentPlan {
                    DiseaseTreatmentPlanID = 7, 
                    DiseaseTreatmentIndicationID = 35, 
                    TreatmentPlanID = 49, 
                    TargetCondition = "Lung lesion", 
                    TreatmentPlanPreferrence = 2,
                    NCCNCategory = "2B"
                },
            };
            DiseaseTreatmentPlans.ForEach(s => context.DiseaseTreatmentPlans.Add(s));
            context.SaveChanges();

            //
     
            var DiseasTreatmentFactors = new List<DiseaseTreatmentFactor>()
            {
                new DiseaseTreatmentFactor { 
                    DiseaseTreatmentFactorID = 1,
                    DiseaseID = 4,  
                    TreatmentFactorID = 1, 
                    HasComposedValue = true,
                    //IsIndependent = true,
                    DependentFactorID = 0,
                    DependentConditionID = string.Empty,
                    Order = 2 
                },
                //central or peripheral
                new DiseaseTreatmentFactor { 
                    DiseaseTreatmentFactorID = 2,
                    DiseaseID = 4,  
                    TreatmentFactorID = 2,  
                    HasComposedValue = false,
                    //IsIndependent = false, 
                    DependentFactorID = 1,
                    DependentConditionID = "1,2",
                    Order = 3 
                },
                //mediastinal lymph node
                new DiseaseTreatmentFactor { 
                    DiseaseTreatmentFactorID = 3,
                    DiseaseID = 4,  
                    TreatmentFactorID = 3,  
                    HasComposedValue = false,
                    //IsIndependent = false, 
                    DependentFactorID = 1,
                    DependentConditionID = "1,2",
                    Order = 4 
                },
                //medical operability
                new DiseaseTreatmentFactor { 
                    DiseaseTreatmentFactorID = 4,
                    DiseaseID = 4,  
                    TreatmentFactorID = 4,  
                    HasComposedValue = false,
                    //IsIndependent = false,  
                    DependentFactorID = 1,
                    DependentConditionID = "1,2,3,4,5,6,7",
                    Order = 5 
                },
                //surgical margin
                new DiseaseTreatmentFactor { 
                    DiseaseTreatmentFactorID = 5, 
                    DiseaseID = 4,  
                    TreatmentFactorID = 5,  
                    HasComposedValue = false,
                    //IsIndependent = false, 
                    DependentFactorID = 1,
                    DependentConditionID = "1,2,3,4,5,6,7",
                    Order = 6 
                },
                //T3 and T4
                new DiseaseTreatmentFactor { 
                    DiseaseTreatmentFactorID = 6, 
                    DiseaseID = 4,  
                    TreatmentFactorID = 6,  
                    HasComposedValue = false,
                    //IsIndependent = false, 
                    DependentFactorID = 1,
                    DependentConditionID = "3,4,5,6",
                    Order = 7 
                },
                //resectability
                new DiseaseTreatmentFactor { 
                    DiseaseTreatmentFactorID = 7, 
                    DiseaseID = 4,  
                    TreatmentFactorID = 7,  
                    HasComposedValue = false,
                    //IsIndependent = false,  
                    DependentFactorID = 1,
                    DependentConditionID = "3,4,5,6,7", //???
                    Order = 8 
                },
                //mediastinal biopsy
                new DiseaseTreatmentFactor { 
                    DiseaseTreatmentFactorID = 8, 
                    DiseaseID = 4,  
                    TreatmentFactorID = 8,  
                    HasComposedValue = false,
                    //IsIndependent = false, 
                    DependentFactorID = 1,
                    DependentConditionID = "3,4,5,6",
                    Order = 9 
                },
                //separate nodule ipsilateral
                new DiseaseTreatmentFactor { 
                    DiseaseTreatmentFactorID = 9, 
                    DiseaseID = 4,  
                    TreatmentFactorID = 9,  
                    HasComposedValue = false,
                    //IsIndependent = false, 
                    DependentFactorID = 1,
                    DependentConditionID = "4,5",
                    Order = 10 
                },
                //solitary or diseminated
                new DiseaseTreatmentFactor { 
                    DiseaseTreatmentFactorID = 10, 
                    DiseaseID = 4,  
                    TreatmentFactorID = 10,  
                    HasComposedValue = false,
                    //IsIndependent = false, 
                    DependentFactorID = 1,
                    DependentConditionID = "7",
                    Order = 11 
                },
                //symptom palliation
                new DiseaseTreatmentFactor { 
                    DiseaseTreatmentFactorID = 11, 
                    DiseaseID = 4,  
                    TreatmentFactorID = 11, 
                    HasComposedValue = false,
                    //IsIndependent = false, 
                    DependentFactorID = 1,
                    DependentConditionID = "7",
                    Order = 12 
                },
                //Cell type
                new DiseaseTreatmentFactor { 
                    DiseaseTreatmentFactorID = 12, 
                    DiseaseID = 4,  
                    TreatmentFactorID = 12,  
                    HasComposedValue = false,
                    //IsIndependent = false, 
                    DependentFactorID = 1,
                    DependentConditionID = "7",
                    Order = 13 
                },
                //EGFR
                new DiseaseTreatmentFactor { 
                    DiseaseTreatmentFactorID = 13,
                    DiseaseID = 4,  
                    TreatmentFactorID = 13,  
                    HasComposedValue = false,
                    //IsIndependent = false, 
                    DependentFactorID = 1,
                    DependentConditionID = "7",
                    Order = 14 
                },
                //ALK
                new DiseaseTreatmentFactor { 
                    DiseaseTreatmentFactorID = 14, 
                    DiseaseID = 4,  
                    TreatmentFactorID = 14,  
                    HasComposedValue = false,
                    //IsIndependent = false,
                    DependentFactorID = 1,
                    DependentConditionID = "7",
                    Order = 15 
                },
                //physical performance
                new DiseaseTreatmentFactor { 
                    DiseaseTreatmentFactorID = 15, 
                    DiseaseID = 4,  
                    TreatmentFactorID = 15,  
                    HasComposedValue = true,
                    //IsIndependent = true, 
                    DependentFactorID = 0,
                    DependentConditionID = string.Empty,
                    Order = 16 
                },
                //is recurrence
                new DiseaseTreatmentFactor { 
                    DiseaseTreatmentFactorID = 16, 
                    DiseaseID = 4,  
                    TreatmentFactorID = 16,  
                    HasComposedValue = false,
                    //IsIndependent = true, 
                    DependentFactorID = 0,
                    DependentConditionID = string.Empty,
                    Order = 1 
                },
            };
            DiseasTreatmentFactors.ForEach(s => context.DiseaseTreatmentFactors.Add(s));
            context.SaveChanges();
            //

            //========================================================================
            //
            //The above block is reserved to explore STUDY related objects
            //
            //========================================================================

            var Procedures = new List<Procedure>
            {
                new Procedure{  ProcedureID = 1, 
                                Name = "Pulmnary Functional Test",   
                                Desc = "Test the functional reserve of your lungs",             
                                //UsedFor = "pre-treatment patient evaluation", 
                                IsImaging = false, 
                                IsInvasive = false, 
                                NameOfTechnology = "PFT" },
                new Procedure{  ProcedureID = 2, 
                                Name = "Bronchoscopy",               
                                Desc = "A procedure that allows your doctor to look inside your lungs' airways, called the bronchi and bronchioles. The airways carry air from the trachea, or windpipe, to the lungs.",                     
                                //UsedFor = "pre-treatment staging", 
                                IsImaging = false, 
                                IsInvasive = true, 
                                NameOfTechnology = "Bronchoscopy"  },
                new Procedure{  ProcedureID = 3, 
                                Name = "Mediastinoscopy",            
                                Desc = "Procedure to exam the space behind your checst bone", 
                                //UsedFor = "pre-treatment staging", 
                                IsImaging = false, 
                                IsInvasive = true, 
                                NameOfTechnology = "Mediastinoscopy"   },
                new Procedure{  ProcedureID = 4, 
                                Name = "Endobronchial ultrasound",   
                                Desc = "An endobronchial ultrasound is a procedure that may be performed during a bronchoscopy, to provide further information to diagnose or determine the stage of a lung cancer. This relatively new technique allows doctors to view regions of your lungs and surrounding chest area that have traditionally required more invasive surgical procedures to evaluate.",                      
                                //UsedFor = "pre-treatment staging", 
                                IsImaging = true, 
                                IsInvasive = true, 
                                NameOfTechnology = "Ultrasound"   },                
                new Procedure{  ProcedureID = 5, 
                                Name = "CT scan for chest and upper abdomen including adrenal glands", 
                                Desc = "Computerized tomograph",                    
                                //UsedFor = "pre-treatment staging", 
                                IsImaging = true, 
                                IsInvasive = false, 
                                NameOfTechnology = "CT"   },
                new Procedure{ProcedureID = 6, Name = "PET scan",                   
                                Desc = "A positron emission tomography (PET) scan is an imaging test that uses a radioactive substance called a tracer to look for disease in the body. A PET scan shows how organs and tissues are working. This is different than magnetic resonance imaging (MRI) and computed tomography (CT), which show the structure of and blood flow to and from organs.",                                  
                                //UsedFor = "pre-treatment staging", 
                                IsImaging = true, 
                                IsInvasive = false, 
                                NameOfTechnology = "PET"   },
                new Procedure{ProcedureID = 7, 
                                Name = "Bone scan",                  
                                Desc = "A bone scan involves injecting a very small amount of radioactive material (radiotracer) into a vein. The substance travels through your blood to the bones and organs. As it wears off, it gives off a little bit of radiation. This radiation is detected by a camera that slowly scans your body. The camera takes pictures of how much radiotracer collects in the bones.",                                 
                                //UsedFor = "pre-treatment staging", 
                                IsImaging = true, 
                                IsInvasive = false, 
                                NameOfTechnology = "bone scan"   },
                new Procedure{ProcedureID = 8, 
                                Name = "Chest x-ray",                
                                Desc = "chest x ray is a painless, noninvasive test that creates pictures of the structures inside your chest, such as your heart, lungs, and blood vessels. Noninvasive means that no surgery is done and no instruments are inserted into your body.",                               
                                //UsedFor = "initial diagnosis", 
                                IsImaging = true, 
                                IsInvasive = false, 
                                NameOfTechnology = "X-ray"   },
                new Procedure{ProcedureID = 9, 
                                Name = "Thoracentesis",              
                                Desc = "a procedure to remove excess fluid in the space between the lungs and the chest wall. This space is called the pleural space.",                             
                                //UsedFor = "confirming diagnosis",
                                IsImaging = false, 
                                IsInvasive = true, 
                                NameOfTechnology = "cytology"   },
                new Procedure{ProcedureID = 10, 
                                Name = "Thoracoscopy",              
                                Desc = "uses an endoscope to visually examine the pleura, lungs, and mediastinum and to obtain tissue for testing purposes. An endoscope is an illuminated optic instrument that is inserted through an incision.",                              
                                //UsedFor = "pre-treatment staging", 
                                IsImaging = false, 
                                IsInvasive = true, 
                                NameOfTechnology = "Thoracoscopy"   },
                new Procedure{ProcedureID = 11, 
                                Name = "Sputum cytology",           
                                Desc = "Sputum cytology is the examination of sputum (mucous) under a microscope to look for abnormal or cancerous cells.",                           
                                //UsedFor = "confirming diagnosis",
                                IsImaging = false, 
                                IsInvasive = false, 
                                NameOfTechnology = "cytology"   },
                new Procedure{ProcedureID = 12, 
                                Name = "Fine needle biopsy (FNA)",  
                                Desc = "Fine needle aspiration is a type of biopsy procedure. In fine needle aspiration, a thin needle is inserted into an area of abnormal-appearing tissue or body fluid. As with other types of biopsies, the sample collected during fine needle aspiration can help make a diagnosis or rule out conditions such as cancer. Fine needle aspiration is generally considered a safe procedure. Complications are infrequent.",                  
                                //UsedFor = "confirming diagnosis", 
                                IsImaging = false, 
                                IsInvasive = true, 
                                NameOfTechnology = "biopsy"   },
                new Procedure{ProcedureID = 13, 
                                Name = "Brain MRI scan",  
                                Desc = "Magnetic resonance imaging scans use radio waves and a powerful magnet linked to a computer to create detailed picture of areas inside the body",  
                                //UsedFor = "pre-treatment staging", 
                                IsImaging = true, 
                                IsInvasive = false, 
                                NameOfTechnology = "MRI"   },
                new Procedure{ProcedureID = 14, 
                                Name = "Lymph node biopsy",  
                                Desc = "Lymph node biopsy by any of the following methods: mediastinoscopy, supraclavicular lymph node biopsy, Thoracoscopy, needle biopsy, mediastinotomy, endoscopic (EUS) biopsy, endobronchial ultrasound (EBUS) biopsy",  
                                //UsedFor = "pre-treatment staging", 
                                IsImaging = true, 
                                IsInvasive = false, 
                                NameOfTechnology = "biopsy"   },
                new Procedure{ProcedureID = 15, 
                                Name = "MRI scan of spine, plus thoracic inlet for superior sulcus lesions abutting the spine and aubclavian vessels",  
                                Desc = "Magnetic resonance imaging scans ",  
                                //UsedFor = "pre-treatment staging", 
                                IsImaging = true, 
                                IsInvasive = false, 
                                NameOfTechnology = "MRI"   }
                                
            };
            Procedures.ForEach(s => context.Procedures.Add(s));
            context.SaveChanges();
            //
            var DiseaseProcedures = new List<DiseaseProcedure>
            {
                new DiseaseProcedure { DiseaseProcedureID = 1,  DiseaseID = 4, ProcedureID = 1},
                new DiseaseProcedure { DiseaseProcedureID = 2,  DiseaseID = 4, ProcedureID = 2},
                new DiseaseProcedure { DiseaseProcedureID = 3,  DiseaseID = 4, ProcedureID = 3},
                new DiseaseProcedure { DiseaseProcedureID = 4,  DiseaseID = 4, ProcedureID = 4},
                new DiseaseProcedure { DiseaseProcedureID = 5,  DiseaseID = 4, ProcedureID = 5},
                new DiseaseProcedure { DiseaseProcedureID = 6,  DiseaseID = 4, ProcedureID = 6},
                new DiseaseProcedure { DiseaseProcedureID = 7,  DiseaseID = 4, ProcedureID = 7},
                new DiseaseProcedure { DiseaseProcedureID = 8,  DiseaseID = 4, ProcedureID = 8},
                new DiseaseProcedure { DiseaseProcedureID = 9,  DiseaseID = 4, ProcedureID = 9},
                new DiseaseProcedure { DiseaseProcedureID = 10,  DiseaseID = 4, ProcedureID = 10},
                new DiseaseProcedure { DiseaseProcedureID = 11,  DiseaseID = 4, ProcedureID = 11},
                new DiseaseProcedure { DiseaseProcedureID = 12,  DiseaseID = 4, ProcedureID = 12},
                new DiseaseProcedure { DiseaseProcedureID = 13,  DiseaseID = 4, ProcedureID = 13},
                new DiseaseProcedure { DiseaseProcedureID = 14,  DiseaseID = 4, ProcedureID = 14},
                new DiseaseProcedure { DiseaseProcedureID = 15,  DiseaseID = 4, ProcedureID = 15}
             
            };
            DiseaseProcedures.ForEach(s => context.DiseaseProcedures.Add(s));
            context.SaveChanges();
            //
            var PatientTreatmentConditions = new List<PatientTreatmentCondition>
            {
                new PatientTreatmentCondition {
                    PatientTreatmentConditionID = 1, PatientProfileID = 1, TreatmentConditionID = 68 },
                new PatientTreatmentCondition {
                    PatientTreatmentConditionID = 2, PatientProfileID = 1, TreatmentConditionID = 1 },
                new PatientTreatmentCondition {
                    PatientTreatmentConditionID = 3, PatientProfileID = 1, TreatmentConditionID = 8 },
                new PatientTreatmentCondition {
                    PatientTreatmentConditionID = 4, PatientProfileID = 1, TreatmentConditionID = 12 },
                new PatientTreatmentCondition {
                    PatientTreatmentConditionID = 5, PatientProfileID = 1, TreatmentConditionID = 21 },
                new PatientTreatmentCondition {
                    PatientTreatmentConditionID = 6, PatientProfileID = 1, TreatmentConditionID = 15 },
                //
                new PatientTreatmentCondition {
                    PatientTreatmentConditionID = 7, PatientProfileID = 2, TreatmentConditionID = 68 },
                new PatientTreatmentCondition {
                    PatientTreatmentConditionID = 8, PatientProfileID = 2, TreatmentConditionID = 1 },
                new PatientTreatmentCondition {
                    PatientTreatmentConditionID = 9, PatientProfileID = 2, TreatmentConditionID = 8 },
                new PatientTreatmentCondition {
                    PatientTreatmentConditionID = 10, PatientProfileID = 2, TreatmentConditionID = 12 },
                new PatientTreatmentCondition {
                    PatientTreatmentConditionID = 11, PatientProfileID = 2, TreatmentConditionID = 21 },
                new PatientTreatmentCondition {
                    PatientTreatmentConditionID = 12, PatientProfileID = 2, TreatmentConditionID = 15 },

            };
            PatientTreatmentConditions.ForEach(s => context.PatientTreatmentConditions.Add(s));
            context.SaveChanges();
            
            //var ServiceRequestSteps = new List<ServiceRequestStep>{
            //    new ServiceRequestStep {
            //        ServiceRequestStepID = 1,
            //        ConsultingServiceID = 1, //expert second opinion
            //        StepCode = 1,
            //        StepName = "Patient Profile"
            //    },
            //     new ServiceRequestStep {
            //        ServiceRequestStepID = 2,
            //        ConsultingServiceID = 1, //expert second opinion
            //        StepCode = 2,
            //        StepName = "Condition of Current Disease"
            //    },
            //     new ServiceRequestStep {
            //        ServiceRequestStepID = 3,
            //        ConsultingServiceID = 1, //expert second opinion
            //        StepCode = 3,
            //        StepName = "Patient Medical History"
            //    },
            //     new ServiceRequestStep {
            //        ServiceRequestStepID = 4,
            //        ConsultingServiceID = 1, //expert second opinion
            //        StepCode = 4,
            //        StepName = "Patient Medical Records"
            //    },
            //     new ServiceRequestStep {
            //        ServiceRequestStepID = 5,
            //        ConsultingServiceID = 1, //expert second opinion
            //        StepCode = 5,
            //        StepName = "Payment for Service"
            //    }
            //};
            //ServiceRequestSteps.ForEach(s => context.ServiceRequestSteps.Add(s));
            //context.SaveChanges();

            //var ServiceRequestSubsteps = new List<ServiceRequestSubstep>{
            //    new ServiceRequestSubstep {
            //        ServiceRequestSubstepID = 1,
            //        ServiceRequestStepID = 1,
            //        SubstepCode = 1,
            //        SubstepName = "Diagnosis"
            //    },
            //    new ServiceRequestSubstep {
            //        ServiceRequestSubstepID = 2,
            //        ServiceRequestStepID = 1,
            //        SubstepCode = 2,
            //        SubstepName = "Patient"
            //    },
            //    new ServiceRequestSubstep {
            //        ServiceRequestSubstepID = 3,
            //        ServiceRequestStepID = 2,
            //        SubstepCode = 1,
            //        SubstepName = "Procedures Received"
            //    },
            //    new ServiceRequestSubstep {
            //        ServiceRequestSubstepID = 4,
            //        ServiceRequestStepID = 2,
            //        SubstepCode = 2,
            //        SubstepName = "Current Status I"
            //    },
            //    new ServiceRequestSubstep {
            //        ServiceRequestSubstepID = 5,
            //        ServiceRequestStepID = 2,
            //        SubstepCode = 3,
            //        SubstepName = "Current STtaus II"
            //    },
            //    new ServiceRequestSubstep {
            //        ServiceRequestSubstepID = 6,
            //        ServiceRequestStepID = 2,
            //        SubstepCode = 4,
            //        SubstepName = "Treatment Feasibility"
            //    },
            //    new ServiceRequestSubstep {
            //        ServiceRequestSubstepID = 7,
            //        ServiceRequestStepID = 3,
            //        SubstepCode = 1,
            //        SubstepName = "Medical History"
            //    },
            //    new ServiceRequestSubstep {
            //        ServiceRequestSubstepID = 8,
            //        ServiceRequestStepID = 3,
            //        SubstepCode = 2,
            //        SubstepName = "System Review"
            //    },
            //    new ServiceRequestSubstep {
            //        ServiceRequestSubstepID = 9,
            //        ServiceRequestStepID = 3,
            //        SubstepCode = 3,
            //        SubstepName = "Social History"
            //    },
            //    new ServiceRequestSubstep {
            //        ServiceRequestSubstepID = 10,
            //        ServiceRequestStepID = 3,
            //        SubstepCode = 4,
            //        SubstepName = "Family History"
            //    },
            //    new ServiceRequestSubstep {
            //        ServiceRequestSubstepID = 11,
            //        ServiceRequestStepID = 4,
            //        SubstepCode = 1,
            //        SubstepName = "Upload Medical Record"
            //    },
            //    new ServiceRequestSubstep {
            //        ServiceRequestSubstepID = 12,
            //        ServiceRequestStepID = 4,
            //        SubstepCode = 2,
            //        SubstepName = "Uploadded Medical Record"
            //    },
            //     new ServiceRequestSubstep {
            //        ServiceRequestSubstepID = 13,
            //        ServiceRequestStepID = 5,
            //        SubstepCode = 1,
            //        SubstepName = "Make Payment"
            //    }
            //};
            //ServiceRequestSubsteps.ForEach(s => context.ServiceRequestSubsteps.Add(s));
            //context.SaveChanges();

            //var UserServiceRequests = new List<UserServiceRequest>
            //{
            //    new UserServiceRequest {
            //        UserServiceRequestID = 1,
            //        UserID = 1,
            //        ConsultingServiceID = 1,
            //        PatientProfileID = 1,
            //        DiseaseID = 14,
            //        InsertDate = DateTime.Parse("2015-02-21"), 
            //        LastUpdateDate = DateTime.Parse("2015-08-08")
            //    },
            //    new UserServiceRequest {
            //        UserServiceRequestID = 2,
            //        UserID = 2,
            //        ConsultingServiceID = 1,
            //        PatientProfileID = 2,
            //        DiseaseID = 14,
            //        InsertDate = DateTime.Parse("2012-12-01"), 
            //        LastUpdateDate = DateTime.Parse("2015-10-08")
            //    }
            //};
            //UserServiceRequests.ForEach(s => context.UserServiceRequests.Add(s));
            //context.SaveChanges();

            //var UserServiceRequestSteps = new List<UserServiceRequestStep>
            //{
            //    new UserServiceRequestStep {
            //        UserServiceRequestStepID = 1,
            //        UserServiceRequestID = 1,
            //        ServiceRequestStepID = 1,
            //        Status = ServiceRequestStepStatus.Complete
            //    },
            //    new UserServiceRequestStep {
            //        UserServiceRequestStepID = 2,
            //        UserServiceRequestID = 1,
            //        ServiceRequestStepID = 2,
            //        Status = ServiceRequestStepStatus.Complete
            //    },
            //    new UserServiceRequestStep {
            //        UserServiceRequestStepID = 3,
            //        UserServiceRequestID = 1,
            //        ServiceRequestStepID = 3,
            //        Status = ServiceRequestStepStatus.Complete
            //    },
            //    new UserServiceRequestStep {
            //        UserServiceRequestStepID = 4,
            //        UserServiceRequestID = 1,
            //        ServiceRequestStepID = 4,
            //        Status = ServiceRequestStepStatus.InProgress
            //    },
            //    new UserServiceRequestStep {
            //        UserServiceRequestStepID = 5,
            //        UserServiceRequestID = 1,
            //        ServiceRequestStepID = 5,
            //        Status = ServiceRequestStepStatus.New
            //    }
            //};
            //UserServiceRequestSteps.ForEach(s => context.UserServiceRequestSteps.Add(s));
            //context.SaveChanges();

            //var UserServiceRequestSubsteps = new List<UserServiceRequestSubstep>
            //{
            //    new UserServiceRequestSubstep {
            //        UserServiceRequestSubstepID = 1,
            //        UserServiceRequestStepID = 1,
            //        ServiceRequestSubstepID = 1,
            //        IsProcessed = true
            //    },
            //    new UserServiceRequestSubstep {
            //        UserServiceRequestSubstepID = 2,
            //        UserServiceRequestStepID = 1,
            //        ServiceRequestSubstepID = 2,
            //        IsProcessed = true
            //    },
            //    new UserServiceRequestSubstep {
            //        UserServiceRequestSubstepID = 3,
            //        UserServiceRequestStepID = 2,
            //        ServiceRequestSubstepID = 1,
            //        IsProcessed = true
            //    },
            //    new UserServiceRequestSubstep {
            //        UserServiceRequestSubstepID = 4,
            //        UserServiceRequestStepID = 2,
            //        ServiceRequestSubstepID = 2,
            //        IsProcessed = true
            //    },
            //    new UserServiceRequestSubstep {
            //        UserServiceRequestSubstepID = 5,
            //        UserServiceRequestStepID = 2,
            //        ServiceRequestSubstepID = 3,
            //        IsProcessed = true
            //    },
            //    new UserServiceRequestSubstep {
            //        UserServiceRequestSubstepID = 6,
            //        UserServiceRequestStepID = 2,
            //        ServiceRequestSubstepID = 4,
            //        IsProcessed = true
            //    },
            //    new UserServiceRequestSubstep {
            //        UserServiceRequestSubstepID = 7,
            //        UserServiceRequestStepID = 3,
            //        ServiceRequestSubstepID = 1,
            //        IsProcessed = true
            //    },
            //    new UserServiceRequestSubstep {
            //        UserServiceRequestSubstepID = 8,
            //        UserServiceRequestStepID = 3,
            //        ServiceRequestSubstepID = 2,
            //        IsProcessed = true
            //    },
            //    new UserServiceRequestSubstep {
            //        UserServiceRequestSubstepID = 9,
            //        UserServiceRequestStepID = 3,
            //        ServiceRequestSubstepID = 3,
            //        IsProcessed = true
            //    },
            //    new UserServiceRequestSubstep {
            //        UserServiceRequestSubstepID = 10,
            //        UserServiceRequestStepID = 3,
            //        ServiceRequestSubstepID = 4,
            //        IsProcessed = true
            //    },
            //    new UserServiceRequestSubstep {
            //        UserServiceRequestSubstepID = 11,
            //        UserServiceRequestStepID = 4,
            //        ServiceRequestSubstepID = 1,
            //        IsProcessed = true
            //    },
            //    new UserServiceRequestSubstep {
            //        UserServiceRequestSubstepID = 12,
            //        UserServiceRequestStepID = 4,
            //        ServiceRequestSubstepID = 2,
            //        IsProcessed = false
            //    },
            //    new UserServiceRequestSubstep {
            //        UserServiceRequestSubstepID = 13,
            //        UserServiceRequestStepID = 4,
            //        ServiceRequestSubstepID = 3,
            //        IsProcessed = false
            //    },
            //    new UserServiceRequestSubstep {
            //        UserServiceRequestSubstepID = 14,
            //        UserServiceRequestStepID = 4,
            //        ServiceRequestSubstepID = 4,
            //        IsProcessed = false
            //    },
            //    new UserServiceRequestSubstep {
            //        UserServiceRequestSubstepID = 15,
            //        UserServiceRequestStepID = 5,
            //        ServiceRequestSubstepID = 1,
            //        IsProcessed = false
            //    }
            //};
            //UserServiceRequestSubsteps.ForEach(s => context.UserServiceRequestSubsteps.Add(s));
            //context.SaveChanges();

        }
    }
}