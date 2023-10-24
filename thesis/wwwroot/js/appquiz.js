

const questionNumber = document.querySelector(".question-number");
const questionText = document.querySelector(".question-text");
const optionContainer = document.querySelector(".option-container");
const answersIndicatorContainer = document.querySelector(".answers-indicator");
const homeBox = document.querySelector(".home-box");
const quizBox = document.querySelector(".quiz-box");
const resultBox = document.querySelector(".result-box");
let questionCounter = 0;
let currentQuestion;
let availableQuestions = [];
let availableOptions = [];
let correctAnswers = 0;
let attempt = 0;

function setAvailableQuestions() {
    const totalQuestion = quiz.length;
    for (let i = 0; i < totalQuestion; i++) {
        availableQuestions.push(quiz[i])
    }

}


function getNewQuestion() {
    questionNumber.innerHTML = " Question " + (questionCounter + 1) + " of " + quiz.length;
    const questionIndex = availableQuestions[Math.floor(Math.random() * availableQuestions.length)]
    currentQuestion = questionIndex;
    questionText.innerHTML = currentQuestion.q;
    const index1 = availableQuestions.indexOf(questionIndex);
    availableQuestions.splice(index1, 1);


    const optionLen = currentQuestion.options.length
    for (let i = 0; i < optionLen; i++) {
        availableOptions.push(i)
       
    }
    optionContainer.innerHTML = '';
    let animationDelay = 0.15;
    for (let i = 0; i < optionLen; i++) {
        const optionIndex = availableOptions[Math.floor(Math.random() * availableOptions.length)];
        const index2 = availableOptions.indexOf(optionIndex);
        availableOptions.splice(index2, 1);

        const option = document.createElement("div");
        option.innerHTML = currentQuestion.options[optionIndex];
        option.id = optionIndex;
        option.style.animationDelay = animationDelay + 's';
        animationDelay = animationDelay + 0.15; 
        option.className = "option";
        optionContainer.appendChild(option);
        option.setAttribute("onclick", "getResult(this)");
        option.addEventListener('click', handleChoiceClick); // Add this line to bind the click event

    }
    questionCounter++
}
function handleChoiceClick(event) {
    highlightChoice(event.target);
}

function highlightChoice(choiceElement) {
    // First, remove highlighting from all choices
    document.querySelectorAll('.option').forEach(option => {
        option.classList.remove('active-choice');
    });

    // Add the 'active-choice' class to the clicked choice
    choiceElement.classList.add('active-choice');
}
function getResult(element) {
    const id = parseInt(element.id);

    element.classList.add("selected");

    if (id === currentQuestion.answer) {
        updateAnswersIndicator("correct");
        correctAnswers++;
    } else {
        updateAnswersIndicator("wrong");
        // This code still checks which option was the correct one, but it no longer visually indicates it
        // for (let i = 0; i < optionLen; i++) {
        //     if (parseInt(optionContainer.children[i].id) === currentQuestion.answer) {
        //         optionContainer.children[i].classList.add("correct");
        //     }
        // }
    }

    attempt++;
    unclickableOptions();
}


function unclickableOptions() {
    const optionLen = optionContainer.children.length;
    for (let i = 0; i < optionLen; i++) {
        optionContainer.children[i].classList.add("already-answered");
    }
}
function answersIndicator() {
    answersIndicatorContainer.innerHTML = '';
    const totalQuestion = quiz.length;
    for (let i = 0; i < totalQuestion; i++) {
        const indicator = document.createElement("div");
        answersIndicatorContainer.appendChild(indicator);

    }
}
function updateAnswersIndicator(markType) {
    answersIndicatorContainer.children[questionCounter - 1].classList.add(markType)
}
function next() {
    if (questionCounter === quiz.length) {
        console.log("quiz over")
        quizOver();

    }
    else {
        getNewQuestion();
    }
}
function quizOver() {
    quizBox.classList.add("hide");
    resultBox.classList.remove("hide");
    quizResult();
}
//function quizResult() {
//    resultBox.querySelector(".total-question").innerHTML = quiz.length;
//    resultBox.querySelector(".total-attempt").innerHTML = attempt;
//    resultBox.querySelector(".total-correct").innerHTML = correctAnswers;
//    resultBox.querySelector(".total-wrong").innerHTML = attempt - correctAnswers;

//    const percentage = (correctAnswers / quiz.length) * 100;
//    resultBox.querySelector(".percentage").innerHTML = percentage.toFixed(2) + "%"; // Fixed the usage of toFixed()

//    resultBox.querySelector(".total-score").innerHTML = correctAnswers + " / " + quiz.length;

//    $.ajax({
//        url: "/MTVquiz/SavePercentage",
//        type: "POST",
//        data: { percentage: percentage.toFixed(2) },
//        success: function (response) {
//            console.log("Percentage sent successfully:", response);
//        },
//        error: function (error) {
//            console.log("Error sending percentage:", error);
//        }
//    });
//}
function resetQuiz() {
    questionCounter = 0;
    correctAnswers = 0;
    attempt = 0;
}
function tryAgainQuiz() {
    resultBox.classList.add("hide");
    quizBox.classList.remove("hide");
    resetQuiz();
    startQuiz();
}

function goToHome() {
    resultBox.classList.add("hide");
    homeBox.classList.remove.add("hide");
    resetQuiz();
}
// #### starting point####
function startQuiz() {
    homeBox.classList.add("hide");
    quizBox.classList.remove("hide");
    setAvailableQuestions();
    getNewQuestion();
    answersIndicator();
}

// Function that gets called when a choice is clicked
function handleChoiceClick(event) {
    // Your logic for what happens when a choice is clicked

    // For example, highlight the clicked choice:
    highlightChoice(event.target);
}

// Function to highlight a choice (turn its background white, for instance)
function highlightChoice(choiceElement) {
    // First, remove highlighting from all choices
    document.querySelectorAll('.option').forEach(option => {
        option.classList.remove('active-choice');
    });

    // Add the 'active-choice' class to the clicked choice
    choiceElement.classList.add('active-choice');
}

// Bind the handleChoiceClick function to the click event of each choice
document.querySelectorAll('.choice-btn').forEach(btn => {
    btn.addEventListener('click', handleChoiceClick);
});


window.onload = function () {
    homeBox.querySelector(".total-question").innerHTML = quiz.length;
}

document.addEventListener("DOMContentLoaded", function () {
    var modal = document.getElementById("myModal");
    var videoModal = document.getElementById("videoModal");
    var videoContainer = document.getElementById("videoContainer");

    // Open modal when FB link button is clicked
    document.getElementById("fblink").addEventListener("click", function () {
        videoModal.style.display = "block";
    });

    // Display the video when "Click here for pop-up video" is clicked
    document.getElementById("drivelink").addEventListener("click", function () {
        videoModal.style.display = "block";  // Show the video modal
        videoContainer.classList.remove("hidden");  // Ensure the video is visible
    });

    // Exit modal buttons
    document.getElementById("btnExit").addEventListener("click", function () {
        modal.style.display = "none";
    });
    document.getElementById("btnExitVideo").addEventListener("click", function () {
        videoModal.style.display = "none";
    });

    // Outside click closes modal
    window.onclick = function (event) {
        if (event.target === modal) {
            modal.style.display = "none";
        } else if (event.target === videoModal) {
            videoModal.style.display = "none";
        }
    };
});

