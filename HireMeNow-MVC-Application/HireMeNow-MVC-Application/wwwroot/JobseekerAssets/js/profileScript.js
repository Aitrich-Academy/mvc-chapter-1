

    var profileModel = {
        Id: null,
        About: null,
        Skills: [],
        Education: null,
        Experiences: null
    };
    (function () {
        'use strict';
        var profileForm = $("#profileForm");
        $(document).ready(function () {

            profileForm.submit(function (e) {
                // prevent Default functionality
              /*  e.preventDefault();*/
                // pass the action-url of the form
                $('#Skills').val(JSON.stringify(profileModel.Skills));
                $('#profileForm').submit();
            });

        });
    function editAbout() {

        var div = document.getElementById("aboutMeTxtDiv");
    div.classList.toggle("show");
    var btnUpdate = document.getElementById("btnSaveChanges");
    btnUpdate.classList.toggle("show");
    var div2 = document.getElementById("aboutMeContentDiv");
    div2.classList.toggle("hidden");


    }
    function ShowAddSkill() {
        var div = document.getElementById("skillInput");
    div.classList.toggle("show");
    var btnUpdate = document.getElementById("btnAddSkill");
    btnUpdate.classList.toggle("show");
        //var div2 = document.getElementById("aboutMeContentDiv");
        //div2.classList.toggle("hidden");
    }

    function ShowAddEducation() {
        var div = document.getElementById("education-form");
    div.classList.toggle("show");
    var btnUpdate = document.getElementById("btnAddEducation");
    btnUpdate.classList.toggle("show");
        //var div2 = document.getElementById("aboutMeContentDiv");
        //div2.classList.toggle("hidden");
    }

    function ShowAddExperience() {
        var div = document.getElementById("experience-form");
    div.classList.toggle("show");
    var btnUpdate = document.getElementById("btnAddExperience");
    btnUpdate.classList.toggle("show");

    }
    //function UpdateAboutMe(parameter) {

        //    console.log("Parameter: " + parameter);

        //    $.ajax({
        //        url: '/Profile?handler=UpdateAboutMe',
        //        type: 'POST',
        //        data: { parameter: parameter },
        //        success: function (result) {
        //            console.log("Server response: " + result);
        //            // You can update the UI or perform other actions based on the server response
        //        },
        //        error: function (error) {
        //            console.log("An error occurred: " + error);
        //        }
        //    });
        //}

        function addSkill() {
            var skillInput = $('#skillInput');
            var skillList = $('#skillsList');

            var skill = skillInput.val();
            if (skill.length > 0) {
                skillList.append('<li>' + skill + '</li>');
                profileModel.Skills.push(skill);
                skillInput.val('');

                // Update the model's Skills list
                //var skills = JSON.parse($('#Skills').val());
                //skills.push(skill);
                //$('#Skills').val(JSON.stringify(skills));

                //// Submit the form to update the model in the server
                //$('#profileForm').submit();
            }
        }

    })();

