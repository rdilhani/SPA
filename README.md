# 📊 Student Performance Evaluation & Skill Domain Prediction System

## 📌 Overview

This project presents a **Machine Learning–based system** for evaluating student academic performance and predicting their **employability skill domains** using both formative and summative assessment data.

The system is designed to support **data-driven decision-making in education**, helping educators identify student strengths, weaknesses, and suitable career pathways.

---

## 🎯 Objectives

* Evaluate student performance using:

  * Formative assessments (continuous evaluation)
  * Summative assessments (GPA, final exams)
* Predict student **skill domains** based on:

  * Academic results
  * Entry qualifications
  * General test scores
* Map student performance to **employability skills**
* Provide insights for:

  * Personalized learning
  * Curriculum improvement
  * Career guidance

---

## 🧠 Key Concepts

### 📘 Educational Data Mining (EDM)

Used to analyze student data and extract meaningful patterns.

### 🤖 Machine Learning (ML)

Supervised learning models are used to predict skill levels.

### 🏷️ Bloom’s Taxonomy

Skill domains are categorized into:

* Cognitive (thinking)
* Affective (attitude)
* Psychomotor (practical skills)

---

## 🏗️ System Architecture

1. **Data Collection**

   * Synthetic dataset (simulating real student data)
   * Includes:

     * Formative scores
     * GPA
     * O/L grades (Math, English)
     * General test scores

2. **Data Preprocessing**

   * Data cleaning
   * Encoding categorical variables
   * Feature scaling
   * Train-test split (80/20)

3. **Feature Selection**

   * Formative Assessment
   * GPA
   * General Test
   * O/L Grades

4. **Model Development**

   * Algorithms used:

          * XGBClassifier
    

5. **Model Evaluation**

   * Accuracy
   * Precision
   * Recall
   * F1-score
     ✅ Achieved accuracy: **94%**

6. **Deployment**

   * Web application using **Streamlit**
   * Real-time predictions

---

## 🧮 Skill Level Classification

| Level   | Description  |
| ------- | ------------ |
| Level 1 | Foundational |
| Level 2 | Developing   |
| Level 3 | Competent    |
| Level 4 | Proficient   |
| Level 5 | Innovative   |

---

## ⚙️ Technologies Used

* **Python**
* **Streamlit**
* **Scikit-learn**
* **Pandas / NumPy**
* **Pickle (model serialization)**

---

## 🚀 How to Run the Project

### 1️⃣ Clone the Repository

```bash
git clone https://github.com/your-username/your-repo-name.git
cd your-repo-name
```

### 2️⃣ Install Dependencies

```bash
pip install -r requirements.txt
```

### 3️⃣ Run the Application

```bash
streamlit run app.py
```

---

## 📂 Project Structure

```
├── data/                  # Dataset (synthetic)
├── models/                # Trained ML models (.pkl)
├── app.py                 # Streamlit application
├── preprocessing.py       # Data preprocessing scripts
├── training.py            # Model training scripts
├── requirements.txt       # Dependencies
└── README.md              # Project documentation
```

---

## 📈 Features

* 📊 Student performance evaluation
* 🧠 Skill domain prediction
* ⚡ Real-time results via web interface
* 📉 Data visualization (optional extension)
* 🎯 Career-oriented insights

---

## ⚠️ Limitations

* Uses **synthetic data** (not real student data)
* Model performance may vary with real-world datasets
* Limited feature set (can be expanded)

---

## 🔮 Future Improvements

* Use real institutional datasets
* Add deep learning models
* Integrate with LMS (Learning Management Systems)
* Enhance visualization dashboards
* Deploy as a cloud-based system

---

## 📚 Research Contribution

This project contributes to:

* Educational Data Mining in Sri Lanka
* Skill-based student evaluation
* Bridging academic performance and employability

---

## 📄 Citation (Zenodo)



```
Wepathana, Y. M. R. D. (2025). 
Student Performance Evaluation and Skill Domain Prediction using Machine Learning. 
[Zenodo. https://doi.org/xxxxx](https://doi.org/10.5281/zenodo.20144619)
```

---

## 👩‍💻 Author

**Y M R D Wepathana**
Assistant Lecturer in Information Technology
Advanced Technological Institute – Kegalle

---

## 📜 License

This project is licensed under the MIT License - see the LICENSE file for details.

---

## 🤝 Acknowledgements

* SLIATE – ATI Kegalle
* Research references in Educational Data Mining and Machine Learning

---

## ⭐ Final Note

This project demonstrates how **machine learning can transform education** by moving beyond grades to **skill-based insights and employability prediction**.


