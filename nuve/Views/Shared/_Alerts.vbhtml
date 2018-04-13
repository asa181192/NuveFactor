@Imports nuve.Helpers

@code
  Dim alerts = If(TempData.ContainsKey(Alert.TempDataKey), _
                   DirectCast(TempData(Alert.TempDataKey), List(Of Alert)), _
                   New List(Of Alert))
  
  If alerts.Any Then
    For Each alert In alerts
      Dim dismissableClass = If(alert.Dismissable, "alert-dismissable", Nothing)
      @<div class="alert alert-@alert.AlertStyle @dismissableClass" role="alert">
            @If alert.Dismissable Then
                  @<button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times</button>
                End If
            @If alert.AlertStyle = "success" Then
               @<strong>Listo! </strong>@Html.Raw(alert.Message)
                End If
            @If alert.AlertStyle = "info" Then
               @<strong>Informaci&oacute;n! </strong>@Html.Raw(alert.Message)
                End If
            @If alert.AlertStyle = "warning" Then
               @<strong>Advertencia! </strong>@Html.Raw(alert.Message)
                End If
            @If alert.AlertStyle = "danger" Then
               @<strong>Error! </strong>@Html.Raw(alert.Message)
                End If               
        </div>
    Next  
  End If
    
End Code