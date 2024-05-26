/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package dataAPI;
import Bean.Robot;
import DAO.RobotsListDAO;
import com.fasterxml.jackson.core.JsonProcessingException;
import jakarta.ws.rs.GET;
import jakarta.ws.rs.Path;
import com.fasterxml.jackson.databind.ObjectMapper;
import java.util.ArrayList;
import java.util.List;

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
