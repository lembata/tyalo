const User = {
  IsLoggedId: () => {
    return !!localStorage.getItem("accessToken");
  }
}

export default User
