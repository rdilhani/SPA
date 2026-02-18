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
performance_model = pickle.load(open('E:/RESEARCH DOCUMENTS/Research Projects/Student Performance/student_skill_model.sav', 'rb'))

# Load the saved encoders
#le_math = pickle.load(open('E:/RESEARCH DOCUMENTS/Research Projects/Student Performance/math_grade_encoder.pkl', 'rb'))
le_math = joblib.load("E:/RESEARCH DOCUMENTS/Research Projects/Student Performance/math_grade_encoder.pkl")
le_english = pickle.load(open('E:/RESEARCH DOCUMENTS/Research Projects/Student Performance/english_grade_encoder.pkl', 'rb'))
le_internship = pickle.load(open('E:/RESEARCH DOCUMENTS/Research Projects/Student Performance/internship_encoder.pkl', 'rb'))
le_program = pickle.load(open('E:/RESEARCH DOCUMENTS/Research Projects/Student Performance/program_encoder.pkl', 'rb'))

#web app
st.set_page_config(layout="wide") # Use the full browser width
st.title('Student Performance Analizer')
st.markdown("""
            This system analyzes student academic records and predicts their **Skill Domain** based on Machine Learning techniques .
            """
            )
# sidebar for navigation
#with st.sidebar:
selected = option_menu('Skill Prediction',
                           ['Competancy Level','Skill','Recommendations'],
                           icons=['bar-chart-fill', 'tools', 'lightbulb-fill'],
                           default_index=0)
    
if selected == 'Competancy Level':

         
        col1, col2 = st.columns(2)   
        
        with col1:
            # input fields
            Formative = st.text_input('Formative_Assessment Mark')
            GPA = st.text_input('GPA')
            GTM = st.text_input('General Test Mark')
            MathOL = st.text_input('Math Grade O/L')
            EngOL = st.text_input('English Grade O/L')
            Intern = st.text_input('Internship')
            Program = st.text_input('Program')
         
            # prediction code
            comp_predict = ''
        
           # if st.button('Predict Skill Domain'):
               # comp_predict = performance_model.predict([[float(Formative), float(GPA), float(GTM),MathOL,EngOL,Intern,Program]])
                
                #st.success(f"Predicted Skill Domain: **{comp_predict}**")
                
                ####################
                
            if st.button('Predict Competency Level'):
                try:
                    # 1. Transform categorical text inputs into numbers
                    
                    math_encoded = le_math.transform([MathOL])[0]
                    eng_encoded = le_english.transform([EngOL])[0]
                    intern_encoded = le_internship.transform([Intern])[0]
                    program_encoded = le_program.transform([Program])[0]
            
                    # 2. Organize features in the same order as training
                    features = np.array([[
                        float(Formative), 
                        float(GPA), 
                        float(GTM),
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
                          'GPA',
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
                        
                with col2:
                        
                        
                        grade_score_map = {
                                'S': 0.25,
                                'C': 0.50,
                                'B': 0.75,
                                'A': 1.00
                            }
                            
                        recommendation_map = {
                                'Academic Mastery': "Improve GPA through structured revision and academic mentoring.",
                                'Continuous Learning': "Increase engagement in formative assessments and weekly exercises.",
                                'Foundational Knowledge': "Strengthen core concepts using bridging modules.",
                                'Analytical Skills': "Enhance problem-solving and quantitative practice.",
                                'Communication Skills': "Improve English communication through presentations and reports.",
                                'Practical Skills': "Focus on hands-on training and supervised internship activities."
                            }
                        
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


                        
                        # ---- Predicting Competency ----
                        st.subheader("🎯 Predicted Competency Level")
                        competency_level = performance_model.predict(features)
                        st.success(f"Competency Level: **{competency_level[0]}**")
                        
                        st.success(f"Predicted Skill Domain: **{comp_predict}**")
                        
                        
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
                                'Academic Mastery': normalize(float(GPA), 2.0, 4.0),
                                'Continuous Learning': normalize(float(Formative), 0, 100),
                                'Foundational Knowledge': normalize(float(GTM), 0, 100),
                                'Analytical Skills': grade_score_map.get(MathOL, 0.0),
                                'Communication Skills': grade_score_map.get(EngOL, 0.0),
                                'Practical Skills': float(intern_encoded)
                            }
                        
                        #---- domain Scores per student ----
                        
                        #---- Identify week areas ----
                        st.subheader("🔍 Weak Area Analysis")
                        def identify_weak_areas(domain_scores, threshold=0.6):
                                return [domain for domain, score in domain_scores.items() if score < threshold]
                            
                        weak_areas = identify_weak_areas(domain_scores)
                        
                        for area, score in domain_scores.items():
                                    score = float(score)
                                    score = max(0.0, min(1.0, score))
                                
                                    st.write(area)
                                    st.progress(score)
                                    
                    #---- Recommendations ----
                        st.subheader("📌 Overall Performance and Recommendations")
                              
                        if weak_areas:
                                recommendations = [recommendation_map[w] for w in weak_areas]
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

                        recommendations = competency_based_recommendations(
                        competency_level[0]
                        )
                            
                        for rec in recommendations:
                            st.info(rec)  
                        
                        
                    #----weak_area_recommendations----

                        def weak_area_recommendations(domain_scores, threshold=0.6):
                            recs = []
                        
                            if domain_scores['Analytical Skills'] < threshold:
                                recs.append("Enroll in quantitative analysis, statistics, or logical reasoning courses")
                        
                            if domain_scores['Communication Skills'] < threshold:
                                recs.append("Follow professional English, business communication, or presentation skills courses")
                        
                            if domain_scores['Academic Mastery'] < threshold:
                                recs.append("Consider academic writing and research methodology programs")
                        
                            if domain_scores['Practical Skills'] < threshold:
                                recs.append("Gain industry exposure through internships, apprenticeships, or practical training")
                            
                            else:
                                recs.append("no weak areas")
                        
                            return recs
                        
                        st.subheader("📌 Weak_area_recommendations")

                        recommendations = weak_area_recommendations(domain_scores)
                                                 
                        for rec in recommendations:
                            st.info(rec)  
                            
                        st.subheader("📌 Future Academic & Career Recommendations")

                        def performance_aligned_recommendations(program, competency_level):
                            program_data = aca_career_paths.get(program, {})
                            level_data = program_data.get(competency_level, {})
                        
                            return {
                                "academic": level_data.get("academic", []),
                                "career": level_data.get("career", [])
                            }

                        paths = performance_aligned_recommendations(Program, competency_level[0])

                        st.subheader("🎓 Academic Progression")
                        for a in paths["academic"]:
                            st.success(a)

                        st.subheader("💼 Career Opportunities")
                        for c in paths["career"]:
                            st.info(c)

