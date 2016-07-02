
@section Scripts {
    @Scripts.Render("~/bundles/jqueryval")
    @Scripts.Render("~/bundles/jqueryui")
    @Scripts.Render("~/Scripts/FileInput/canvas-to-blol.min.js")
    @Scripts.Render("~/Scripts/FileInput/fileinput.min.js")
    @Scripts.Render("~/Scripts/jquery.ui.monthpicker.js")
    @Scripts.Render("~/Scripts/jquery.unobtrusive-ajax.js")
    <script>
    var $steps = $(".row.step div");
    var $tabs = $("#step-1-content ul:first li");
    //var activeStep = 'step-1';
    var formChanged = false;
    //var activeTab = $tabs.filter('.active').find('a').attr('href');
    var profileCreated = false;
    @if(ViewBag.ProfileCreated){
        @:profileCreated = true;
    }
    var currentStepIndex = $steps.filter('.activestep').index();

      

    var currentTabIndex = $tabs.filter('.active').index();
    var targetStepIndex, targetTabIndex;
    var visited = [5];
    for (var i = 0; i < 5; i++) {
        visited[i] = [4];
        for(var j = 0; j < 4; j ++){
            visited[i][j] = 0;
        }
    }
    visited[0][0] = 1;

    //
    $(function () {
        $(document).on('ready', function () {
            $tabs = $("#step-1-content ul:first li");
            //activeTab = $tabs.filter('.active').find('a').attr('href');
            //activeForm = $(activeTab + " form");


            $("#file-input").fileinput({
                previewFileType: "image",
                previewClass: "bg-warning",
                allowedFileExtension: ["jpg", "gif", "png"],
                browseClass: "btn btn-success",
                browseLabel: "Pick Image",
                browseIcon: "<i class=\"glyphicon glyphicon-picture\"></i>",
                removeClass: "btn btn-danger",
                removeLabel: "Delete",
                removeIcon: "<i class=\"glyphicon glyphicon-trash\"></i>",
                uploadClass: "btn btn-info",
                uploadLabel: "Upload",
                uploadIcon: "<i class=\"glyphicon glyphicon-upload\"></i>"
            });
        });

        $(".large_image").click(function (e) {
            e.preventDefault();
            //alert("image is clicked");
            var href = $(this).attr("href");
            window.open(href, "yyyyy", "height=800,width=800, resizable=no,toolbar=no,menubar=no,location=no,status=no")
        });

        //$(document).on('click', '.PostForm', function () {
        //    //alert("document on SaveData clicked");
        //    var form = $(this).closest('form');
        //    $('#page-loader').modal('show');
        //    form.submit();
        //});

        //$("#ajax-loader").css("display", "none");

        var cache = {};

        $("#disease-name").autocomplete({
            minLength: 2,
            source: function (request, response) {
                var term = request.term;
                if (term in cache) {
                    response(cache[term]);
                    return;
                }
                $.getJSON("/PatientProfile/GetDiseaseNameList", { term: $("#disease-name").val() }, function (data, status, xhr) {
                    //alert(data);
                    cache[term] = data;
                    response(data);
                });
            },
            select: function (event, ui) {
                //works fine
                $("#DiseaseID").val(ui.item.id);
                $("#DiseaseID").change();
            }
        });

        $('input.monthpicker').monthpicker();

        $(document).on('change', 'input, select, textarea', function () {
            formChanged = true;
        });

        hidePageLoader();
    })(jQuery);



    function resetActive(event, step) {
      
        $("div").each(function () {
            if ($(this).hasClass("activestep")) {
                $(this).removeClass("activestep");
            }
        });
        //alert('event.target.className=' + event.target.className);
        if (event.target.className == "col-md-2") {
            $(event.target).addClass("activestep");
            //alert('event.target.className after add1=' + event.target.className);
        }
        else {
            $(event.target.parentNode).addClass("activestep");
            //alert('event.target.className after add2=' + event.target.parentNode.className);
        }
        //alert('mid of resetActive');
        hideInactiveSteps();
        showActiveStep("step-" + step);

    }

    function hideInactiveSteps() {
        $("div").each(function () {
            if ($(this).hasClass("activeStepInfo")) {
                $(this).removeClass("activeStepInfo");
                $(this).addClass("hiddenStepInfo");
            }
        });
    }

    function showActiveStep(step) {
        var id = "#" + step;
        $(id).addClass("activeStepInfo");

        //alert("showCurrentStepInfo=" + id);
        //loadStep(step);

        //$tabs = $(id + "-content ul:first li");
        //activeStep = step;
    }

    function clickStep(event, step) {
        if(profileCreated) {
            targetStepIndex = step - 1;
            targetTabIndex = 0;
            var targetTabVisited = visited[targetStepIndex][targetTabIndex]
            //alert('3');
            if (formChanged || targetTabVisited == 0) {
                alert('formChanged=' + formChanged);
                alert('targetTabVisited=' + targetTabVisited);
                //submitForm(formChanged, nextStepIndex, nextTabVisited);
            } else {
                showStep(targetStepIndex + 1);
            }
        }else{
            alert("Please create profile before moving to other steps");
        }
    }
    //
    function showStep(step) {
        alert('step='+ step);
        $("div").each(function () {
            if ($(this).hasClass("activestep")) {
                $(this).removeClass("activestep");
            }
        });
        if (event.target.className == "col-md-2") {
            $(event.target).addClass("activestep");
        }
        else {
            $(event.target.parentNode).addClass("activestep");
        }
        hideInactiveSteps();
        showActiveStep("step-" + step);
    }
    //
    function ActivateTab(panelIndex, tabIndex) {
        //alert("ok");
        hidePageLoader();
        if (panelIndex == 0) {
            if (tabIndex == 0) {
                $("#patient_profile_tabs li:eq(0) a").tab('show');
            } else if (tabIndex == 1) {
                $("#patient_profile_tabs li:eq(1) a").tab('show');
            }
        } else if (panelIndex == 1) {
            if (tabIndex == 0) {
                $("#current_condition_tabs li:eq(0) a").tab('show');
            } else if (tabIndex == 1) {
                $("#current_condition_tabs li:eq(1) a").tab('show');
            } else if (tabIndex == 2) {
                $("#current_condition_tabs li:eq(2) a").tab('show');
            } else if (tabIndex == 3) {
                $("#current_condition_tabs li:eq(3) a").tab('show');
            } else {
                $("#div3").trigger("click");
            }
        } else if (panelIndex == 2) {
            if (tabIndex == 0) {
                $("#medical_history_tabs li:eq(0) a").tab('show');
            } else if (tabIndex == 1) {
                $("#medical_history_tabs li:eq(1) a").tab('show');
            } else if (tabIndex == 2) {
                $("#medical_history_tabs li:eq(2) a").tab('show');
            } else if (tabIndex == 3) {
                $("#medical_history_tabs li:eq(3) a").tab('show');
            }
        } else if (panelIndex == 3) {
            if (tabIndex == 0) {
                $("#upload_records_tabs li:eq(0) a").tab('show');
            } else if (tabIndex == 1) {
                $("#upload_records_tabs li:eq(1) a").tab('show');
            } else if (tabIndex == 2) {
                $("#upload_records_tabs li:eq(2) a").tab('show');
            }
        }
    }
    function OnAjaxFailure() {
        hidePageLoader();
   
        alert('The data was not saved, please try again or later');
    }
    function OnAjaxSuccess() {
        alert("OnAjaxSuccess");
        //targetStepIndex and targetTabIndex are set on ClickNext, ClickPrev and ClickStep
        if(currentStepIndex == 0){
            profileCreated = true;
        }
        if (targetStepIndex > currentStepIndex){
            showNextTarget(targetStepIndex, targetTabIndex);
        } else if(targetStepIndex < currentStepIndex) {
            showPrevTarget(targetStepIndex, targetTabIndex);
        } else if(targetTabIndex > currentTabIndex) {
            showNextTarget(targetStepIndex, targetTabIndex);
        } else if(targetTabIndex < currentTabIndex) {
            showPrevTarget(targetStepIndex, targetTabIndex);
        }
        
        if(formChanged = true){
            formChanged = false;
        }
        visited[targetStepIndex][targetTabIndex] = 1;

        hidePageLoader();
    }
    //
    function showPrev() {
        if ($tabs.filter('.active').prev('li').index() == -1) {
            if (formChanged) {
                //submitForm();
                formChanged = false;
            } else if (activeStep == 'step-2') {
                //alert('last index of step-2 is clicked');
                $('#div1').click();
            } else if (activeStep == 'step-3') {
                $('#div2').click();
            } else if (activeStep == 'step-4') {
                $('#div3').click();
            } else if (activeStep == 'step-5') {
                $('#div4').click();
            }
        } else if (formChanged) {
            //submitForm();
            formChanged = false;
        } else {

            $tabs.filter('.active').prev('li').removeClass("disabled");
            $tabs.filter('.active').prev('li').find('a[data-toggle]').each(function () {
                $(this).attr("data-toggle", "tab");
            });

            $tabs.filter('.active').prev('li').find('a[data-toggle="tab"]').tab('show');

            $tabs.filter('.active').next('li').find('a[data-toggle="tab"]').each(function () {
                $(this).attr("data-toggle", "").parent('li').addClass("disabled");
            })
        }
    }

    //function showNext() {
    //    if ($tabs.filter('.active').next('li').index() == -1) {
    //        if (formChanged) {
    //            submitForm();
    //            formChanged = false;
    //        } else if (activeStep == 'step-1') {
    //            //alert('last index of step-2 is clicked');
    //            $('#div2').click();
    //        } else if (activeStep == 'step-2') {
    //            $('#div3').click();
    //        } else if (activeStep == 'step-3') {
    //            $('#div4').click();
    //        } else if (activeStep == 'step-4') {
    //            $('#div5').click();
    //        }

    //    } else if (formChanged) {
    //        submitForm();
    //        formChanged = false;
    //    } else {
    //        $tabs.filter('.active').next('li').removeClass("disabled");

    //        $tabs.filter('.active').next('li').find('a[data-toggle]').each(function () {
    //            $(this).attr("data-toggle", "tab");
    //        });

    //        $tabs.filter('.active').next('li').find('a[data-toggle="tab"]').tab('show');

    //        $tabs.filter('.active').prev('li').find('a[data-toggle="tab"]').each(function () {
    //            $(this).attr("data-toggle", "").parent('li').addClass("disabled");;
    //        })
    //    }
    //}

    function clickNext() {
        currentStepIndex = $steps.filter('.activestep').index();
        currentTabIndex = $tabs.filter('.active').index();
        targetStepIndex = $steps.filter('.activestep').next('div').index();
        targetTabIndex = $tabs.filter('.active').next('li').index();


        alert('currentStepIndex=' + currentStepIndex);
        alert('targetStepIndex=' + targetStepIndex);
        alert('targetTabIndex='+ targetTabIndex);
        //showNext only if valid step is available
        if (targetStepIndex > -1) {
            if (targetTabIndex == -1) {
                //valid next step
                targetTabIndex = 0;
            } else {
                targetStepIndex = currentStepIndex;
                //alert('targetStepIndex=' + targetStepIndex);
            }
            var nextTabVisited = visited[targetStepIndex][targetTabIndex]
            //alert('3');
            if (formChanged || nextTabVisited == 0) {
                alert('formChanged=' + formChanged);
                alert('nextTabVisited=' + nextTabVisited);
                submitForm(formChanged, targetStepIndex, targetTabIndex);
            } else {
                showNextTarget(targetStepIndex, targetTabIndex);
            }
        }
    }

    function showNextTarget(targetStepIndex, targetTabIndex) {
        if (targetTabIndex > 0) {
            //same step, next tab 
            $tabs.filter('.active').next('li').removeClass("disabled");
            $tabs.filter('.active').next('li').find('a[data-toggle]').each(function () {
                $(this).attr("data-toggle", "tab");
            });
            $tabs.filter('.active').next('li').find('a[data-toggle="tab"]').tab('show');
            $tabs.filter('.active').prev('li').find('a[data-toggle="tab"]').each(function () {
                $(this).attr("data-toggle", "").parent('li').addClass("disabled");;
            })
        } else {
            //next step, first tab (targetTabIndex = 0)
            $tabs = $("#step-" + (targetStepIndex+1) + "-content ul:first li");
            $(".row.step div:eq(" + targetStepIndex + ")").click();
        }
    }

    function submitForm(formChanged, targetStep, targetTab) {
        var activeTab = $tabs.filter('.active').find('a').attr('href');
        var activeForm = $(activeTab + " form");

        alert("form url=" + activeForm.attr('action'));
        
        buildHiddenInputs(activeForm);

        alert('form hidden==' + activeForm.find('input[name="nextPage"]').val());

        activeForm.submit();
        showPageLoader();
    }

    function showPageLoader() {
        $('#page-loader').modal('show');
    }
    function hidePageLoader() {
        $('#page-loader').modal('hide');
    }
    function buildHiddenInputs(activeForm) {
        var newTraget = "";
        if (visited[targetStepIndex][targetTabIndex] == 0) {
            newTraget = targetStepIndex + "-" + targetTabIndex
        }
        activeForm.append("<input type='hidden' name='pageModified' value='" + formChanged + "'>")
            .append("<input type='hidden' name='nextPage' value='" + newTraget + "'>");
    }
    //function getActiveTabIndex(activeTabId) {
    //    var activeTabIndex = 0;
    //    switch (activeTabId) {
    //        case "patient":
    //        case "current_state":
    //        case "system_review":
    //        case "uploadded_record":
    //            activeTabIndex = 1;
    //            break;
    //        case "evaluation":
    //        case "family_history":
    //            activeTabIndex = 2;
    //            break;
    //        case "overall_health":
    //        case "social_history":
    //            activeTabIndex = 3;
    //            break;
    //        default:
    //            activeTabIndex = 0;
    //    }
    //    return activeTabIndex;
    //}
    </script>
}