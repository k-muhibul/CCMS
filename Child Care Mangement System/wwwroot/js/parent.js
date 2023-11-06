


    $(document).ready(function(){
        $("#clockOutBtn").on("click", function () {
           

        })

        function clockOut() {
            console.log("Here")
            var childId = $("#clockOutBtn").data("child-id");
            console.log(ChildId)
            $.ajax({
                url: "/Parent/ClockOutChild",
                type: "POST",
                data: { ChildId: childId },
                success: function (response) {
                    // Handle the JSON response here
                    console.log(response);
                    // You can update the UI or perform other actions as needed
                },
                error: function (error) {
                    console.error("Error:", error);
                }
            });

        }



    })




