import axios from 'axios';


export default {
    async updateValuesCellAxios(week,id){
      try {
      await axios.put(`http://localhost:5000/api/kpvitem/${id}`,week)
      console.log("updated");
      console.log(week);
    } catch (e) {
      this.errors.push(e)
    }
    return id;
  },

  async addValuesAxios(week) {
    console.log(week);
    try {
      await axios.post(`http://localhost:5000/api/kpvitem`,week,)
    } catch (e) {
      this.errors.push(e)
    }
  },

  async deleteValuesAxios(week,id){
    //console.log(id);
    try {
      await axios.delete(`http://localhost:5000/api/kpvitem/${id}`)
    } catch (e) {
    this.errors.push(e)
  }
    console.log("deleted axios")
},
}
