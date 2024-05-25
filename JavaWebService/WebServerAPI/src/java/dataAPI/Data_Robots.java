/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package dataAPI;

import Bean.Robot;
import DAO.RegistraDAO;
import DAO.RobotsListDAO;
import com.fasterxml.jackson.core.JsonProcessingException;
import jakarta.ws.rs.Consumes;
import jakarta.ws.rs.DefaultValue;
import jakarta.ws.rs.GET;
import jakarta.ws.rs.POST;
import jakarta.ws.rs.Path;
import jakarta.ws.rs.QueryParam;
import jakarta.ws.rs.core.Form;
import jakarta.ws.rs.core.Response;
import com.fasterxml.jackson.databind.ObjectMapper;
import jakarta.ws.rs.core.MediaType;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;


/**
 *
 * @author Dante
 */
@Path("robots")
public class Data_Robots {
    
    
    @GET
    public String getRobots() {
         ObjectMapper objectMapper = new ObjectMapper();
         String jsonData;
        
         List<Robot> dummyList = RobotsListDAO.getListRobots();
        List<Robot> robots = new ArrayList<Robot>();
        
        try {
  
           
            
            jsonData = objectMapper.writeValueAsString(dummyList);
        } catch (JsonProcessingException ex) {
             //  return Response.status(Response.Status.INTERNAL_SERVER_ERROR).build();
             return ex.toString();
        }
        
        return jsonData;
         // return Response.ok(jsonData, MediaType.APPLICATION_JSON).build();

        
    }

}
