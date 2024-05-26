/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package dataAPI;

import Bean.Player;
import DAO.PlayerDAO;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import jakarta.ws.rs.Consumes;
import jakarta.ws.rs.DELETE;
import jakarta.ws.rs.GET;
import jakarta.ws.rs.PUT;
import jakarta.ws.rs.Path;
import jakarta.ws.rs.PathParam;
import jakarta.ws.rs.core.MediaType;
import jakarta.ws.rs.core.Response;
import java.util.List;

/**
 *
 * @author Dante
 */
@Path("players")
public class Data_Player {

    @GET
    public Response getPlayer() {
        ObjectMapper objectMapper = new ObjectMapper();
        String jsonData;
        List<Player> elencoPlayer = PlayerDAO.getListMissions();

        try {
            jsonData = objectMapper.writeValueAsString(elencoPlayer);

        } catch (JsonProcessingException ex) {
            return Response.status(Response.Status.INTERNAL_SERVER_ERROR).build();
        }
        return Response.ok(jsonData, MediaType.APPLICATION_JSON).build();

    }

    @DELETE
    @Path("/{id}")
    public Response deletePlayer(@PathParam("id") String idPlayer) {

        PlayerDAO.deletePlayer(idPlayer);

        return Response.status(Response.Status.ACCEPTED).build();
    }
    
    @PUT
    @Consumes(MediaType.APPLICATION_JSON)
    public Response PUT_Dipendente(Player player) {
        try {
           
          String risposta = PlayerDAO.modifyPlayer(player.getId() , player.getUsername() ,  player.getRole(),player.getEmail());
          return Response.ok(risposta).build();
      
        } catch (Exception e) {
            return Response.status(Response.Status.INTERNAL_SERVER_ERROR).build();
        }
    }
}
