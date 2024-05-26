/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package dataAPI;

import Bean.Ritrovamenti;

import DAO.RitrovamentiDAO;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import jakarta.ws.rs.Consumes;

import jakarta.ws.rs.GET;
import jakarta.ws.rs.POST;
import jakarta.ws.rs.Path;

import jakarta.ws.rs.QueryParam;
import jakarta.ws.rs.core.Form;
import jakarta.ws.rs.core.MediaType;
import jakarta.ws.rs.core.Response;
import java.util.List;

/**
 *
 * @author Dante
 */
@Path("ritrovamenti")
public class Data_Ritrovamenti {
    
    
    @GET
    public Response getRitrovamenti() {
        ObjectMapper objectMapper = new ObjectMapper();
        String jsonData;
        List<Ritrovamenti> elencoRitrovamenti = RitrovamentiDAO.getListRitrovamenti();

        try {
            jsonData = objectMapper.writeValueAsString(elencoRitrovamenti);

        } catch (JsonProcessingException ex) {
            return Response.status(Response.Status.INTERNAL_SERVER_ERROR).build();
        }
        return Response.ok(RitrovamentiDAO.getListRitrovamenti(), MediaType.APPLICATION_JSON).build();

    }

    @GET
    @Path("/{byID}")
    public Response getRitrovamentiBYMissionID(@QueryParam("idMissione") String missionID) {
        ObjectMapper objectMapper = new ObjectMapper();
        String jsonData;
      List<Ritrovamenti> elencoRitrovamenti = RitrovamentiDAO.getListRitrovamentiByMissionID(missionID);

        try {
            jsonData = objectMapper.writeValueAsString(elencoRitrovamenti);

        } catch (JsonProcessingException ex) {
            return Response.status(Response.Status.INTERNAL_SERVER_ERROR).build();
        }
        return Response.ok(jsonData, MediaType.APPLICATION_JSON).build();

    }
    
     @POST
    @Consumes("application/x-www-form-urlencoded")
    public String addPlayer(Form form) {
        try {
            String missione = form.asMap().getFirst("missione");
            int materiale = Integer.parseInt(form.asMap().getFirst("materiale"));
            String data = form.asMap().getFirst("data");
            int parziali = Integer.parseInt(form.asMap().getFirst("parziali"));
          
            
        
       
            return  RitrovamentiDAO.addRitrovamenti( missione, materiale, data, parziali);
        } catch (Exception e) {
            return "Errore nella API";
        }
    }

   
}