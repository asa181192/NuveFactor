

@code
  
    Dim FechaActual As Date = Nothing   
  
    FechaActual = Date.Now
          
    @<footer class="footer">                
      &nbsp;@Session("NAME")&#64;
      <b> | </b>@Session("OFICINA")
      <b> | </b>@Session("ESTADO")
      <span style="float: right;">
        @FechaActual.ToString("dddd")&#44;
        @FechaActual.ToString("dd")
        de
        @FechaActual.ToString("MMMM")
        de
        @FechaActual.ToString("yyyy")        
        @FechaActual.ToString("hh:mm tt")        
      </span>
    </footer>
    

End Code