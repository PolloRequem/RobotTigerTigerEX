/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Bean;

import com.fasterxml.jackson.annotation.JsonProperty;

/**
 *
 * @author Dante
 */
public class Player {

    @JsonProperty("id")
    private int id;
    @JsonProperty("username")
    private String username;
    @JsonProperty("role")
    private String role;
    @JsonProperty("email")
    private String email;
    @JsonProperty("totalPoints")
    private int totalPoints;
    @JsonProperty("missionsCompleted")
    private int missionsCompleted;

    public int getId() {
        return id;
    }

    public int getMissionsCompleted() {
        return missionsCompleted;
    }

    public void setMissionsCompleted(int missionsCompleted) {
        this.missionsCompleted = missionsCompleted;
    }

    public int getTotalPoints() {
        return totalPoints;
    }

    public void setTotalPoints(int totalPoints ) {
        this.totalPoints = totalPoints ;
    }

    public String getUsername() {
        return username;
    }

    public String getRole() {
        return role;
    }

    public String getEmail() {
        return email;
    }

    public Player() {
    }

    public Player(int id, String username, String role, String email, int  totalPoints , int missionsCompleted) {
        this.id = id;
        this.username = username;
        this.role = role;
        this.email = email;
        this.totalPoints = totalPoints ;
        this.missionsCompleted = missionsCompleted;
    }

 

    public void setId(int id) {
        this.id = id;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public void setRole(String role) {
        this.role = role;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    @Override
    public String toString() {
        return "Player{" + "id=" + id + ", username=" + username + ", role=" + role + ", email=" + email + ", ToTpoints=" + totalPoints + ", missionsCompleted=" + missionsCompleted + '}';
    }

    

}
