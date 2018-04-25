@Code
    ViewData("Title") = "Monitor"
End Code

@Section scripts
    <script src="~/Scripts/jquery.signalR-2.2.3.js" type="text/javascript"></script>
    <script type="text/javascript" src="~/signalr/hubs"></script>
End Section

<script type="text/javascript">

    $(function () {
        var notificationHub = $.connection.notificationHub;

        notificationHub.client.sendMessage = function (content) {
            $("#target")
               .find('ul')
               .append($("<li></li>").html(content));
        };

        $.connection.hub.start();

    });

</script>

<h2>Monitor</h2>

<div id = "target">
   <ul></ul>
</div>