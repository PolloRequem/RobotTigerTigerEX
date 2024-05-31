/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package dataAPI;

import Bean.Mission;
import DAO.MissionListDAO;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import jakarta.ws.rs.Consumes;
import jakarta.ws.rs.GET;
import jakarta.ws.rs.POST;
import jakarta.ws.rs.PUT;
import jakarta.ws.rs.Path;
import jakarta.ws.rs.PathParam;
import jakarta.ws.rs.core.Form;
import jakarta.ws.rs.core.MediaType;
import jakarta.ws.rs.core.Response;
import java.util.List;


/**
 *
 * @author Dante
 */
@Path("missions")
public class Data_Missions {

    @GET
    public Response getMissionsID() {
        ObjectMapper objectMapper = new ObjectMapper();
        String jsonData;
        List<Mission> elencoMissioni = MissionListDAO.getListMissions();

        try {
            jsonData = objectMapper.writeValueAsString(elencoMissioni);

        } catch (JsonProcessingException ex) {
            return Response.status(Response.Status.INTERNAL_SERVER_ERROR).build();
        }
        return Response.ok(jsonData, MediaType.APPLICATION_JSON).build();

    }

    @GET
    @Path("/{idMission}")
    public Response getMissionsIDS(@PathParam("idMission") String idMission) {
        ObjectMapper objectMapper = new ObjectMapper();
        String jsonData;
        List<Mission> elencoMissioni = MissionListDAO.getListMissions();

        try {
            jsonData = objectMapper.writeValueAsString(elencoMissioni);

        } catch (JsonProcessingException ex) {
            return Response.status(Response.Status.INTERNAL_SERVER_ERROR).build();
        }
        return Response.ok(jsonData, MediaType.APPLICATION_JSON).build();

    }

    @POST
    @Consumes("application/x-www-form-urlencoded")
    public String addMission(Form form) {
        try {
          String id =  form.asMap().getFirst("id");
          String nome =  form.asMap().getFirst("nome");
          String robot =  form.asMap().getFirst("robot");
          String player =  form.asMap().getFirst("player");
            
            
        
       
            return   MissionListDAO.addMission(id, nome, robot, player);
        } catch (Exception e) {
            return "Errore nella API";
        }
    }
    
    @PUT
    @Consumes(MediaType.APPLICATION_JSON)
    public Response PUT_CompleteMission(Mission mission) {
        try {

            String risposta = MissionListDAO.completeMissions(mission.getId(), mission.getPunteggio() ,mission.getDataFine());
            return Response.ok(risposta).build();

        } catch (Exception e) {
            return Response.ok(e.toString()).build();
        }
    }
}