# -*- coding: utf-8 -*-
"""
Created on Sun Oct 26 16:00:25 2025

@author: USER
"""

import pickle
import joblib
import streamlit as st
from streamlit_option_menu import option_menu
import numpy as np
import pandas as pd

#load the trained model
with open('student_skill_model.sav', 'rb') as file:
    performance_model = pickle.load(file)
            
# Load the saved encoders
with open('math_grade_encoder.pkl', 'rb') as file:
    le_math = pickle.load(file)
with open('english_grade_encoder.pkl', 'rb') as file:
    le_english = pickle.load(file)
with open('internship_encoder.pkl', 'rb') as file:
    le_internship = pickle.load(file)
with open('program_encoder.pkl', 'rb') as file:
    le_program = pickle.load(file)

# --------------------------------------------------
# PAGE CONFIGURATION
# --------------------------------------------------
#web app
st.set_page_config(layout="wide") # Use the full browser width
st.title('Student Performance Evaluation Platform')
st.markdown("""
            This system analyzes student academic records and predicts their **Skill Domain** based on Machine Learning techniques .
            """
            )
# sidebar for navigation

# --------------------------------------------------
# SIDEBAR CONFIGURATION (ADMIN)
# --------------------------------------------------

st.sidebar.subheader("🎓 Program")
Program = st.sidebar.selectbox("Academic Program", ["HND in Accountancy", "HND in English", "HND in IT", "HND in Project Management"])

st.sidebar.subheader("📌 Pre Course Ability / Program Entry Requirements")
math_grade = st.sidebar.selectbox("Analytical Skill", ["A", "B", "C", "S"])
eng_grade = st.sidebar.selectbox("Communication Skill", ["A", "B", "C", "S"])
gtm = st.sidebar.slider("Logical and Aptitude Skills", 0, 100, 25)


st.sidebar.header("🔧 Institute Configuration")

num_semesters = st.sidebar.slider("Number of Semesters", 1, 8, 4)

formative_mode = st.sidebar.radio(
    "Select Formative Assessment Method",
    ["Rubric-Based", "Auto-Derived from Marks"]
)

# --------------------------------------------------
# HELPER FUNCTIONS
# --------------------------------------------------
grade_map = {"A": 1.0, "B": 0.8, "C": 0.6, "S": 0.4}

def calculate_fai_rubric(semesters):
    return np.mean(semesters)

def calculate_fai_auto(assignments, max_mark=100):
    normalized = [a / max_mark for a in assignments]
    return np.mean(normalized)

def predict_competency(gpa, fai, internship):
    score = (0.4 * gpa/4) + (0.4 * fai) + (0.2 * internship)

    if score >= 0.85:
        return "Innovative"
    elif score >= 0.70:
        return "Proficient"
    elif score >= 0.55:
        return "Competent"
    elif score >= 0.40:
        return "Developing"
    else:
        return "Foundational"

def weak_area_analysis(analytical, communication, practical):
    return {
        "Analytical Skills": analytical,
        "Communication Skills": communication,
        "Practical Skills": practical
    }

def generate_weak_area_recommendations(weak_areas):
    recs = []
    is_weak=True
    for area, score in weak_areas.items():
        if score < 0.6:
            if area == "Analytical Skills":
                recs.append("Enroll in analytical reasoning or data analysis short courses.")
            if area == "Communication Skills":
                recs.append("Follow professional communication or academic writing programs.")
            if area == "Practical Skills":
                recs.append("Participate in hands-on workshops or applied internships.")
        else:
            is_weak=False
    if is_weak==False:
        recs.append("No significant blind spots!")
    return recs

def future_pathways(level):
    pathways = {
        "Innovative": [
            "Postgraduate degree (MSc / MBA)",
            "Research assistantships",
            "Leadership-track roles"
        ],
        "Proficient": [
            "Professional certifications",
            "Industry specialization diplomas",
            "Advanced technical roles"
        ],
        "Competent": [
            "Skill-bridging short courses",
            "Graduate trainee programs"
        ],
        "Developing": [
            "Foundation professional courses",
            "Extended internship programs"
        ],
        "Foundational": [
            "Skill recovery programs",
            "Re-orientation or bridging diplomas"
        ]
    }
    return pathways.get(level, [])


#with st.sidebar:
#selected = option_menu('Skill Prediction',
        #                   ['Competancy Level','Skill','Recommendations'],
              #             icons=['bar-chart-fill', 'tools', 'lightbulb-fill'],
           #                default_index=0)
    
#if selected == 'Competancy Level':

st.header("🧾 Student Data Input") 
        
col1, col2 = st.columns(2)   
        
with col1:                      
        # input fields            
 
        st.subheader("Learning process")
        gpa = st.number_input("Final GPA", 0.0, 4.0, 2.5)
        
        semester_scores = []

        if formative_mode == "Rubric-Based":
            st.subheader("Rubric-Based Semester Evaluation")
            for s in range(1, num_semesters+1):
                st.markdown(f"**Semester {s}**")
                c1, c2, c3, c4 = st.columns(4)
                with c1:
                    consistency = st.slider(f"Consistency S{s}", 0, 100, 70)
                with c2:
                    cognitive = st.slider(f"Cognitive S{s}", 0, 100, 65)
                with c3:
                    communication = st.slider(f"Communication S{s}", 0, 100, 60)
                with c4:
                    practical = st.slider(f"Practical S{s}", 0, 100, 68)
        
                semester_scores.append(np.mean([consistency, cognitive, communication, practical]) / 100)
        
            fai = calculate_fai_rubric(semester_scores)
        
        else:
            st.subheader("Auto-Derived from Assignment Marks")
            for s in range(1, num_semesters+1):
                mark = st.number_input(f"Average Assignment Mark – Semester {s}", 0, 100, 60)
                semester_scores.append(mark)
        
            fai = calculate_fai_auto(semester_scores)      
 
evaluated=False
with col2:  
        st.subheader("Post-course outcome")
                 
        internship = st.selectbox("Internship Status", ["PASS", "FAIL"])
        internship_score = 1.0 if internship == "PASS" else 0.3
            
        # prediction code
        comp_predict = ''
        
         # if st.button('Predict Skill Domain'):
        # comp_predict = performance_model.predict([[float(Formative), float(GPA), float(GTM),MathOL,EngOL,Intern,Program]])
                
        #st.success(f"Predicted Skill Domain: **{comp_predict}**")
                
        ####################
                
        if st.button("🚀 Evaluate Student Performance"):
            competency = predict_competency(gpa, fai, internship_score)
            evaluated=True
    
            st.subheader("🎯 Predicted Competency Level")
            st.success(f"**{competency}**")

  
            #analytical = (grade_map[math_grade] + fai) / 2
            #communication = (grade_map[eng_grade] + fai) / 2
            #practical = fai
            
               # st.subheader("🔍 Weak Area Analysis")
              #  weak_areas = weak_area_analysis(analytical, communication, practical)
            
               # for area, score in weak_areas.items():
                #        st.write(f"{area}: {int(score*100)}%")
                #        st.progress(float(score))
            
               # st.subheader("📌 Targeted Improvement Recommendations")
               # for rec in generate_weak_area_recommendations(weak_areas):
               #         st.info(rec)
            
              #  st.subheader("🎓 Future Academic & Career Pathways")
             #   for path in future_pathways(competency):
               #         st.success(path)  
                        
            try:
                    # 1. Transform categorical text inputs into numbers
                                
                math_encoded = le_math.transform([math_grade])[0]
                eng_encoded = le_english.transform([eng_grade])[0]
                intern_encoded = le_internship.transform([internship])[0]
                program_encoded = le_program.transform([Program])[0]
                        
                    # 2. Organize features in the same order as training
                features = np.array([[
                    float(fai), 
                    float(gpa), 
                    float(gtm),
                    math_encoded,
                    eng_encoded,
                    intern_encoded,
                    program_encoded
                ]])
                                
                                
            except ValueError as e:
                st.error(f"Error: Ensure all inputs are valid. {e}")
                        
                        #----Evaluating Feature Importance----
            feature_names = [
                'Formative_Assessment',
                'gpa',
                'General_Test',
                'Math_Grade_OL',
                'English_Grade_OL',
                'Internship',
                'Program'
                ]
            
            st.subheader("📊 Feature Importance")
            
            importance = pd.Series(
                performance_model.feature_importances_, index=feature_names
                ).sort_values(ascending=False)
                
            
            st.bar_chart(importance)
                                                       
                                    
if evaluated:                                                              
    recommendation_map = {
                    'Academic Mastery': "Re-learn difficult subjects using simpler resources, you’ll perform better in next courses, exams, or professional certifications",
                    'Continuous Learning': "Practice daily or weekly learning habits (even 30–45 mins),Do extra exercises beyond syllabus,Use platforms like:Khan Academy/Coursera",
                    'Foundational Knowledge': "Go back to core concepts,use simple tutorials,beginner textbooks,step-by-step examples",
                    'Analytical Skills': "Practice logical reasoning,basic statistics.",
                    'Communication Skills': "Practice speaking daily,write short reports",
                    'Practical Skills': "Focus on hands-on training and supervised internship activities."
                    }
              
                
                                        
                                       # ---- Predicting Competency ----
                                
                #competency_level = performance_model.predict(features)
                #st.success(f"Competency Level: **{competency_level[0]}**")
                                        
                #st.success(f"Predicted Skill Domain: **{comp_predict}**")
                                        
                                        
                                        # ---- Skill Dimentions ----
                                        #---- Score normalization ----
    def normalize(value, min_val, max_val):
                    try:
                        value = float(value)
                    except:
                        return 0.0
                                        
                    if max_val == min_val:
                        return 0.0
                                 
                    norm = (value - min_val) / (max_val - min_val)
                    return max(0.0, min(1.0, norm))
                                        
    domain_scores = {
                    'Academic Mastery': normalize(float(gpa), 2.0, 4.0),
                    'Continuous Learning': normalize(float(fai), 0, 100),
                    'Foundational Knowledge': normalize(float(gtm), 0, 100),
                    'Analytical Skills': grade_map.get(math_grade, 0.0),
                    'Communication Skills': grade_map.get(eng_grade, 0.0),
                    'Practical Skills': float(intern_encoded)
                 }
                                        
                                        #---- domain Scores per student ----
                                  
                                        #---- Identify week areas ----
    st.subheader("🔍 Skill Analysis")
    
    def identify_skill_areas(domain_scores, threshold=0.6):
                        return [domain for domain, score in domain_scores.items() if score > threshold]
                                            
    skill_areas = identify_skill_areas(domain_scores)
                                     
    for skill_area, score in domain_scores.items():
                        score = float(score)
                        score = max(0.0, min(1.0, score))
                                                
                        st.write(skill_area)
                        st.progress(score)
                                                    
                                    #---- Recommendations ----
    st.subheader("📌 Skill Improvement Recommendations")
                                              
    if skill_areas:
                            #recommendations = [recommendation_map[w] for w in skill_areas]
                            recommendations=[recommendation_map[w] for w in recommendation_map if w not in skill_areas]
    else:
                            recommendations = ["Excellent performance. Encourage advanced and innovative learning activities."]
                                            
    for rec in recommendations:
                            st.info(rec)
                                               
                                    #----Domain Alignment----
                                        #----competency_based_recommendations----
    def competency_based_recommendations(level):
                                            recs = {
                                                'Innovative': [
                                                    "Enroll in postgraduate programs (Master’s / MBA / MSc)",
                                                    "Pursue professional certifications (CIMA, ACCA, PMP, AWS, Cisco)",
                                                    "Consider research, innovation labs, or leadership roles",
                                                    "Target advanced industry roles or startup opportunities"
                                                ],
                                                'Proficient': [
                                                    "Follow advanced diploma or top-up degree programs",
                                                    "Enroll in industry-recognized professional certifications",
                                                    "Apply for junior to mid-level professional roles",
                                                    "Participate in applied research or capstone projects"
                                                ],
                                                'Competent': [
                                                    "Follow skill-focused short courses related to your field",
                                                    "Enroll in internship-to-employment bridge programs",
                                                    "Strengthen technical and analytical competencies",
                                                    "Target entry-level industry positions"
                                                ],
                                                'Developing': [
                                                    "Enroll in foundation or remedial short courses",
                                                    "Improve academic fundamentals before higher studies",
                                                    "Participate in mentorship and guided training programs",
                                                    "Consider vocational or competency-based training paths"
                                                ],
                                                'Foundational': [
                                                    "Strengthen core academic and language skills",
                                                    "Enroll in certificate-level foundation programs",
                                                    "Delay higher academic progression until competency improves",
                                                    "Focus on employability skills training"
                                                ]
                                            }
                                            return recs.get(level, [])
                                        
    st.subheader("📌 Competency_based_recommendations")
                
    recommendations = competency_based_recommendations(competency)
                                            
    for rec in recommendations:
                    st.info(rec)  
                                        
                                        
    st.subheader("📌 Future Academic & Career Recommendations")
                              
                #---- Academic and career paths ----
    aca_career_paths = {
                    'HND in IT': {
                        'Innovative': {
                            'academic': [
                                "MSc in Computer Science / AI / Data Science",
                                "Research-based postgraduate programs"
                                ],
                            'career': [
                                "Data Scientist",
                                "Software Architect",
                                "Technical Lead"
                                ]
                            },
                        'Proficient': {
                            'academic': [
                                "BSc in IT / Computer Science",
                                "Cloud, Cybersecurity certifications"
                                ],
                            'career': [
                                "Software Engineer",
                                "System Analyst"
                                ]
                            },
                        'Competent': {
                            'academic': [
                                "Advanced Diploma in IT",
                                "Vendor certifications (AWS, Cisco)"
                                ],
                            'career': [
                                "Junior Software Engineer",
                                "IT Support Officer"
                                ]
                            },
                        'Developing': {
                            'academic': [
                                "IT Skill-bridge programs",
                                "Programming fundamentals courses"
                                ],
                            'career': [
                                "Trainee IT Assistant"
                                ]
                            },
                        'Foundational': {
                            'academic': [
                                "Foundation Certificate in Computing"
                                ],
                            'career': [
                                "IT Intern / Apprentice"
                                ]
                            }
                        }
                    }
                         
    def performance_aligned_recommendations(program, competency_level):
        program_data = aca_career_paths.get(program, {})
        level_data = program_data.get(competency_level, {})
                                        
        return {
            "academic": level_data.get("academic", []),
            "career": level_data.get("career", [])
            }
                
    paths = performance_aligned_recommendations(Program, competency)
                
    st.subheader("🎓 Academic Progression")
    for a in paths["academic"]:
                    st.success(a)
                    
    st.subheader("💼 Career Opportunities")
    for c in paths["career"]:
                                    st.info(c)
                
