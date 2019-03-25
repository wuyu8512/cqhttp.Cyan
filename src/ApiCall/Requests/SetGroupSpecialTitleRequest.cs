using cqhttp.Cyan.ApiCall.Requests.Base;

namespace cqhttp.Cyan.ApiCall.Requests {
    /// <summary>
    /// 设置群组专属头衔
    /// </summary>
    public class SetGroupSpecialTitleRequest : ApiRequest {
        long group_id;
        long user_id;
        string special_title;
        long duration;
        /// <param name="group_id">群号</param>
        /// <param name="user_id">要设置的 QQ 号</param>
        /// <param name="special_title">专属头衔，不填或空字符串表示删除专属头衔</param>
        /// <param name="duration">专属头衔有效期，单位秒，-1 表示永久，不过此项似乎没有效果，可能是只有某些特殊的时间长度有效，有待测试</param>
        public SetGroupSpecialTitleRequest (long group_id, long user_id, string special_title = "", long duration = -1) : base ("/set_group_special_title") {
            this.response = new Results.EmptyResult ();
            this.group_id = group_id;
            this.user_id = user_id;
            this.special_title = special_title;
            this.duration = duration;
        }
        ///
        public override string content {
            get {
                return $"{{\"group_id\":{group_id},\"user_id\":{user_id},\"special_title\":\"{Config.asJsonStringVariable(special_title)}\",\"duration\":{duration}}}";
            }
        }
    }
}