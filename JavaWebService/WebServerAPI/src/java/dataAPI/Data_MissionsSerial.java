/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package dataAPI;


import DAO.MissionListDAO;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import jakarta.ws.rs.GET;
import jakarta.ws.rs.Path;
import jakarta.ws.rs.core.MediaType;
import jakarta.ws.rs.core.Response;
import java.util.List;

/**
 *
 * @author Dante
 */
@Path("missions/serials")
public class Data_MissionsSerial {
    
    
     @GET
    public Response getMissionsID() {
        ObjectMapper objectMapper = new ObjectMapper();
        String jsonData;
         List<String>  elencoMissioni = MissionListDAO.getListSerialiMissions();
        
         try {
             jsonData = objectMapper.writeValueAsString(elencoMissioni);
         
        
         } catch (JsonProcessingException ex) {
            return Response.status(Response.Status.INTERNAL_SERVER_ERROR).build();
         }
          return Response.ok(jsonData, MediaType.APPLICATION_JSON).build();

        
    }
}
