// JavaScript to show the modal when clicking on .facebook-container1
document.querySelector(".facebook-container1").addEventListener("click", function () {
    var modal = document.getElementById("myModal");
    modal.style.display = "block";
});

// JavaScript to close the modal when clicking on the exit button or outside the modal
document.getElementById("btnExit").addEventListener("click", function () {
    var modal = document.getElementById("myModal");
    modal.style.display = "none";
});

// JavaScript to handle the "FacebookLink" button click
document.getElementById("fblink").addEventListener("click", function () {
    // Open the link in a new tab
    window.open("https://www.facebook.com/nmis11safemeatforall/videos/917356236418111?idorvanity=370501063649021", "_blank");
});

// JavaScript to show the modal when clicking on .facebook-container1
document.querySelector(".facebook-container1").addEventListener("click", function () {
    var modal = document.getElementById("myModal");
    modal.style.display = "block";
});

// JavaScript to close the first modal when clicking on the exit button or outside the modal
document.getElementById("btnExit").addEventListener("click", function () {
    var modal = document.getElementById("myModal");
    modal.style.display = "none";
});


// JavaScript to handle the "Click here for pop-up video" button click
document.getElementById("drivelink").addEventListener("click", function () {
    // Show the second modal with the video
    var videoModal = document.getElementById("videoModal");
    videoModal.style.display = "block";
});

// JavaScript to close the video modal when clicking on the exit button or outside the modal
document.getElementById("btnExitVideo").addEventListener("click", function () {
    var videoModal = document.getElementById("videoModal");
    videoModal.style.display = "none";
});







const quiz = [
    {
        q: 'Unsa nga klase sa kagaw ang pwede makita sa karne sa manok? Mao kini ang rason ngano kinahanglan nga dili moubos sa 4 ˚C ang kabugnaw sa karne ug mao pud kini ang rason ngano ginabanlawan og chilled chlorinated water ang manok sulod sa balay ihawanan.',
        options: ['1', '2', '3', '4'],
        answer: 1
    },
    {
        q: 'Kung ang imong "meat van registration" mo-expire karong December 28, 2022, kanus-a ka dapat mag-renew?',
        options: [' Dili na kinahanglan mag renew', ' February 30, 2022', ' November 28, 2022', 'December 27, 2022'],
        answer: 1
    },
    {
        q: 'Unsa ang pwedeng buhaton sa NMIS Enforcement sa mga karne nga gikarga sa usa ka meat van nga gikargahan uban sa ligid, kaang, ug pesticides bisag adunay gipresenta nga NMIS Meat Inspection Certificate o MIC? ',
        options: [' Presohon ang driver ug helper', ' Kumpiskahon ang produkto ug ang sakyanan', ' Pasayawon og Budots', 'Kumpiskahon ang produkto ug isyuhan og Post-Abbatoir Control Receipt '],
        answer: 1
    },
    {
        q: 'Tinuud o Dili Tinuod. Ok ra nga expired ang imong rehistro sa LTO kung mag rehistro ka sa imong meat van?',
        options: ['Tinuod', 'Dili Tinuod'],
        answer: 1
    },
    {
        q: 'Pwede ba ikarga ang frozen fish uban sa frozen meat sa usa ka meat van? ',
        options: ['Oo', 'Dili'],
        answer: 1
    },
    {
        q: 'Unsa ang saktong temperatura sa usa ka "Frozen" meat sama sa "imported meat"? ',
        options: ['100 ˚C (100 Degree Celsius)', '0-4 ˚C (0-4 Degree Celsius)', '-18 ˚C (Negative 18 Degree Celsius)', 'None of the above'],
        answer: 1
    },
    {
        q: 'Unsa ang tulo (3) klase sa "hazard" mga maong hinungdan sa "cross-contamination"? ',
        options: [' Mental, Spiritual, Financial', 'Physical, Psychological, Catastrophic', 'Chemical, Physical, Sexual', 'Physical, Chemical, Emotional', "Chemical, Physical, Biological"],
        answer: 1
    },
    {
        q: 'Mga pamaagi kini aron malikayan ang "cross-contamination".',
        options: ['Maligo kada adlaw, mubo nga kuko, ahit sa balbas ug bigote', 'Hinluan og i-disinfect ang Meat Van kada human sa byahe', 'Kanunay nga maghugas sa kamot', 'Dili pagsul-ob og mga alahas sama sa relo, sing-sing, ug mga ariyos kung naga-karga ug diskarga sa karne', "Mag report bisan pa og gikalibanga", "Kanunay i-check ang refrigeration unit", "Likayan ang temperature danger zone (4-60 ˚C)", "I-check kung naa bay sinyales ang meat van ginapuy-an og mga ok-ok, ilaga, ug uban pa", "Pagsul-ob og Personal Protective Equipments (PPE) sama sa botas, facemask, ug hairnet", "I-check ang kalidad sa karne usa ikarga sa meat van"],
        answer: 1
    },
    {
        q: 'Ang pag karga sa Accredited Meat Van og mga produkto gawas sa karne mamahimong muresulta sa?.',
        options: ['Dakong halin', 'Dugang Negosyo', 'Kumpikasyon sa produkto ug revocation sa Certificate of Registration', 'Pagkapreso'],
        answer: 1
    },
    {
        q: 'Si Mr. Kanor nagsuot og kumpleto nge PPE kon Personal Protective Equipment (hairnet, mask, boots) aron maka saka-kanaog ra sya sa yuta ug sa meat van. Nakatabang ba si Mr. Kanor makalikay sa "Cross-Contamination"? ',
        options: ['Oo', 'Wala'],
        answer: 1
    },
    {
        q: 'Unsa ning ginatawag nga "hot meat"?',
        options: ['Bagong luto nga karne', 'Karne nga walay dokumento', 'Karne nga init', 'Karne nga wala na-inspect sa meat inspector', "Karne nga wala giihaw sa accredited nga balay-ihawan", "Bagong ihaw nga karne", "Karne nga smuggled"],
        answer: 1
    },
    {
        q: 'Adunay mga grano sa chlorine nga namatikdan sulod sa Meat Van. Unsa kini na klase sa "Food Hazard"? ',
        options: ['1', '2', '3', '4'],
        answer: 1
    },
    {
        q: 'Mao kini ang possible nga mahitabo kung kita makaviolate sa Food Safety ',
        options: ['Mahatagan og License', 'Makapadayon sa negosyo', 'Makamulta/Makasuhan', 'Maka tiktok'],
        answer: 1
    },
    {
        q: 'Unsa ang importansya nga kasabot ang mga drivers ug helpers mahinungod sa "food safety"? ',
        options: ['Aron lang magka certificate', 'Aron makalikay sa sakit', 'Aron makalikay sa food poisoning', 'Aron di mahimong zombie', "Aron sakto ang pag handle sa karne", "Aron di ta makakatag og kagaw", "Aron di dali madaot ang karne", "Aron makapangilad"],
        answer: 1
    },
    {
        q: ' Pwede magkargag karne gikan sa dili accredited nga balay-ihawan nga ibaligya sa ubang lungsod?',
        options: ['Oo', 'Dili'],
        answer: 1
    },
    {
        q: 'Pwede magkargag karne gikan sa dili accredited nga balay-ihawan nga ibaligya sa ubang lungsod? ',
        options: ['Staphylococcus aureus', 'Norovirus', 'Salmonella', 'Yakult'],
        answer: 1
    },
]
    