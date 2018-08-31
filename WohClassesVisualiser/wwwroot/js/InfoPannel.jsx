class InfoPannel extends React.Component {

    constructor(props) {
        super(props);
        this.state = { type: "", data: "" };
    }

    render() {
        return <div id="InfoPannel" style={{ float: 'left', border: '3px solid #000', height: '726px', width: '300px' }}>
            <p>InfoPannel</p>
            <p>{this.props.type}</p>
            <p>{this.props.data}</p>
            <form asp-action="Login" asp-controller="Account" method="post">
                <div class="form-group">
                    <label>Email</label>
                    <label asp-validation-for="Email" class="text-danger"></label>
                    <input type="text" asp-for="Email" class="form-control" />
                </div>
                <div class="form-group">
                    <label>Password</label>
                    <label asp-validation-for="Password" class="text-danger"></label>
                    <input type="password" asp-for="Password" class="form-control" />
                </div>
                <div class="form-group">
                    <input type="checkbox" asp-for="RememberMe" /><span>Remember me?</span>
                </div>
                <div class="form-group">
                    <input type="submit" class="btn btn-primary form-control" name="Login" value="Login" />
                </div>
            </form>
        </div>;
    }
}