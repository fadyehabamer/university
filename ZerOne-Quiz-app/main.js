const questionnumber = document.querySelector(".question-num-value");
const questiontotal = document.querySelector(".question-total-value");
const options = document.querySelector(".options").children;
const question = document.querySelector(".question");
const op1 = document.querySelector(".option1");
const op2 = document.querySelector(".option2");
const op3 = document.querySelector(".option3");
const op4 = document.querySelector(".option4");
const correctans = document.querySelector(".correct-answers");
const totalans = document.querySelector(".total-answers");
const percentage = document.querySelector(".percentage");


let questionindex;
let index = 0; // for question number
let myarray = []; //checking dublicates
let score = 0;

/* [THE "DATABASE" - QUESTIONS, OPTIONS, ANSWERS] */
// An array that contains objects
// In the format of {q: QUESTION, o: OPTIONS, a: CORRECT ANSWER}
var questions = [
  {
    q:
      "What is the standard distance between the target and archer in Olympics?",
    o: ["50 meters", "70 meters", "100 meters", "120 meters"],
    a: 1, // arrays start with 0, so it is 70 meters
  },
  {
    q: "Which is the highest number on a standard roulette wheel?",
    o: ["22", "24", "32", "36"],
    a: 3,
  },
  {
    q: "How much wood could a woodchuck chuck if a woodchuck would chuck wood?",
    o: ["400 pounds", "550 pounds", "700 pounds", "750 pounds"],
    a: 2,
  },
  {
    q: "Which is the seventh planet from the sun?",
    o: ["Uranus", "Earth", "Pluto", "Mars"],
    a: 0,
  },
  {
    q: "Which is the largest ocean on Earth?",
    o: ["Atlantic Ocean", "Indian Ocean", "Arctic Ocean", "Pacific Ocean"],
    a: 3,
  },
];

//set questions , answers , question-number
questiontotal.innerHTML = questions.length;
function load() {
  questionnumber.innerHTML = index + 1;
  question.innerHTML = questions[questionindex].q;
  op1.innerHTML = questions[questionindex].o[0];
  op2.innerHTML = questions[questionindex].o[1];
  op3.innerHTML = questions[questionindex].o[2];
  op4.innerHTML = questions[questionindex].o[3];
  index++;
}

function randomquestion() {
  let randomnumber = Math.floor(Math.random() * questions.length);
  let deldub = 0; // dublication
  if (index == questions.length) {
    var next_dis = document.getElementById("next");
    next_dis.style.display="none";
    quizover();
  } else {
    if (myarray.length > 0) {
      for (let i = 0; i < myarray.length; i++) {
        if (myarray[i] == randomnumber) {
          deldub = 1;
          break;
        }
      }
      if (deldub == 1) {
        randomquestion();
      } else {
        questionindex = randomnumber;
        load();
      }
    }

    if (myarray.length == 0) {
      questionindex = randomnumber;
      load();
    }

    myarray.push(randomnumber);
  }
}


function check(element) {
  if (element.id == questions[questionindex].a) {
    element.classList.add("correct");
    score++;
    console.log("score is : "+ score )
  } else {
    element.classList.add("wrong");
  }
  //make user choose only 1 option
  disabled();
}

function disabled() {
  for (let i = 0; i < options.length; i++) {
    options[i].classList.add("disabled");
    if (options[i].id == questions[questionindex].a) {
      options[i].classList.add("correct");
    }
  }
}

function enable() { 
  for (let i = 0; i < options.length; i++) {
    options[i].classList.remove("disabled", "correct", "wrong");
  }
}

function validate() {
  if (!options[0].classList.contains("disabled")) {
    alert("you must select any option");
  } else {
    enable();
    randomquestion();
    
  }
}

function next() {
  validate();
}

function quizover() {
  document.querySelector(".quiz-over").classList.add("show");
  correctans.innerHTML = score;
  totalans.innerHTML = questions.length;
  percentage.innerHTML = (score / questions.length) * 100;
 
  if(percentage.innerHTML == 100){
  document.querySelector(".full").classList.add("show-meme");
  }
  else if(percentage.innerHTML == 80){
    document.querySelector(".eighty").classList.add("show-meme");
  }
  else if(percentage.innerHTML == 60){
    document.querySelector(".sixty").classList.add("show-meme");
  }
  else if(percentage.innerHTML == 40){
    document.querySelector(".forty").classList.add("show-meme");
  }
  else if(percentage.innerHTML == 20){
    document.querySelector(".twenty").classList.add("show-meme");
  }
  else if(percentage.innerHTML == 0){
    document.querySelector(".zero").classList.add("show-meme");
  }
}


function tryagain() {
  window.location.reload();
}

window.onload = function () {
  randomquestion();
};
